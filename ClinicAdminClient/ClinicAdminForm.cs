using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using ContosoMedicalUtilities;

namespace ClinicAdminClient
{
    /// <summary>
    /// Clinic Administration Client form.
    /// </summary>
    public partial class ClinicAdminForm : Form
    {
        #region Variables, initialization, and shut down

        public ClinicAdminForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Doctors tab

        private void getDoctorCount_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ContosoMedicalDAC dac = new ContosoMedicalDAC();
            int count = dac.GetNumberOfDoctors();
            string message = String.Format(
            "There are {0} doctors registered.", count);
            MessageBox.Show(message, "Doctor Count");
        }

        private void showDoctors_Click(object sender, EventArgs e)
        {
            doctorsListBox.Items.Clear();

            string specialty = this.specialtyTextBox.Text;
            if (String.IsNullOrEmpty(specialty))
            {
                ShowAllDoctors();
            }
            else
            {
               ShowDoctorsForSpecialty(specialty);
            }
        }

        private void ShowAllDoctors()
        {
            try
            {
                ContosoMedicalDAC dac = new ContosoMedicalDAC();
                using (SqlDataReader reader = dac.GetAllDoctors())
                {
                    while (reader.Read())
                    {
                        string doctorInfo = string.Format("[{0}]\tDr. {1} {2}, {3}",
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3));
                        doctorsListBox.Items.Add(doctorInfo);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowDoctorsForSpecialty(string specialty)
        {
            try
            {
                // Get doctors for a particular specialty.
                ContosoMedicalDAC dac = new ContosoMedicalDAC();
                int doctorCount, specialtyCount;
                List<Doctor> doctors = dac.GetDoctorsForSpecialty(specialty, out doctorCount, out specialtyCount);

                // Display each doctor in the list.
                foreach (Doctor doctor in doctors)
                {
                    string doctorInfo = string.Format("[{0}]\tDr. {1} {2}, {3}",
                                                       doctor.DoctorID,
                                                       doctor.FirstName,
                                                       doctor.LastName,
                                                       doctor.Specialty);
                    doctorsListBox.Items.Add(doctorInfo);
                }
                string message = string.Format("{0} doctors specialize in {1}.\nThere are {2} registered specialties.",
                                                doctorCount, specialty, specialtyCount);
                MessageBox.Show(message, "Summary Information");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        #endregion
    }
}