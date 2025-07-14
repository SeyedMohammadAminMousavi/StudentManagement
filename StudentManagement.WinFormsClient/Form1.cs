using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement.WinFormsClient
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private int _selectedStudentId = 0; 

        private const string BaseApiUrl = "https://localhost:7256/api/students";

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            LoadStudentsAsync(); 
        }

        private async void btnLoadStudents_Click(object sender, EventArgs e)
        {
            await LoadStudentsAsync();
        }

        private async Task LoadStudentsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseApiUrl);
                response.EnsureSuccessStatusCode(); 
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var students = JsonSerializer.Deserialize<List<Student>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                dataGridViewStudents.DataSource = students;
                dataGridViewStudents.Columns["Id"].Visible = false; 
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error parsing student data: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                MessageBox.Show("Please fill in Full Name and National Code.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = new Student
            {
                FullName = txtFullName.Text,
                NationalCode = txtNationalCode.Text,
                BirthDate = dtpBirthDate.Value
            };

            try
            {
                if (_selectedStudentId == 0) 
                {
                    var jsonContent = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(BaseApiUrl, jsonContent);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    student.Id = _selectedStudentId;
                    var jsonContent = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"{BaseApiUrl}/{_selectedStudentId}", jsonContent);
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearFields();
                await LoadStudentsAsync();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error saving student: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error serializing student data: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                MessageBox.Show("Please select a student to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"{BaseApiUrl}/{_selectedStudentId}");
                    response.EnsureSuccessStatusCode();
                    MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    await LoadStudentsAsync();
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error deleting student: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtFullName.Text = string.Empty;
            txtNationalCode.Text = string.Empty;
            dtpBirthDate.Value = DateTime.Now;
            _selectedStudentId = 0; 
            btnSave.Text = "Add Student";
        }

        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewStudents.Rows[e.RowIndex];
                _selectedStudentId = (int)row.Cells["Id"].Value;
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtNationalCode.Text = row.Cells["NationalCode"].Value.ToString();
                dtpBirthDate.Value = (DateTime)row.Cells["BirthDate"].Value;
                btnSave.Text = "Update Student"; 
            }
        }
    }
}