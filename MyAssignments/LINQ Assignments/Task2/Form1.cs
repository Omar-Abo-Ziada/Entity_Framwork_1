using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //BusinessLogicLayer.Intialize();

            comboBoxDepartments.DisplayMember = "Dname"; // here have to mention the name of prop not sql name
            comboBoxDepartments.ValueMember = "Dnum"; // here have to mention the name of prop not sql name
            comboBoxDepartments.DataSource = DataAccessLayer.GetDepartments();

            comboBoxDepartmentChoose.DisplayMember = "Dname"; // here have to mention the name of prop not sql name
            comboBoxDepartmentChoose.ValueMember = "Dnum"; // here have to mention the name of prop not sql name
            comboBoxDepartmentChoose.DataSource = DataAccessLayer.GetDepartments();

            // Assuming you have a DateTimePicker control named dateTimePicker1
            dateTimePickerBirthDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerBirthDate.CustomFormat = "yyyy-MM-dd"; // Example custom format, you can adjust it as needed

            SSNRequiredMesage.Visible = false;
            fNameRequiredMesage.Visible = false;
            LNameRequiredMesage.Visible = false;
            SalaryRequiredMesage.Visible = false;
            ErrorMsgRepeatedSSN.Visible = false;
            ErrorMsgCantUpdateSSN.Visible = false;
        }

        private void comboBoxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorMsgCantUpdateSSN.Visible = false;
            textBoxSSN.Enabled = true;
            ErrorMsgRepeatedSSN.Visible = false;

            listBoxDepartmentsEmployees.DisplayMember = "fname";
            listBoxDepartmentsEmployees.ValueMember = "SSN";

            int selectedDeptNum = (int)comboBoxDepartments.SelectedValue;

            listBoxDepartmentsEmployees.DataSource = DataAccessLayer.GetDepartmentEmployees(selectedDeptNum);

        }

        private Employee collectEmployeeDate()
        {
            SSNRequiredMesage.Visible = false;
            fNameRequiredMesage.Visible = false;
            LNameRequiredMesage.Visible = false;
            SalaryRequiredMesage.Visible = false;

            bool isValid = true;

            if (textBoxSSN.Text == "")
            {
                isValid = false;
                SSNRequiredMesage.Visible = true;
            }


            if (textBoxFName.Text == "")
            {
                isValid = false;
                fNameRequiredMesage.Visible = true;
            }


            if (textBoxLName.Text == "")
            {
                isValid = false;
                LNameRequiredMesage.Visible = true;
            }


            if (textBoxSalary.Text == "")
            {
                isValid = false;
                SalaryRequiredMesage.Visible = true;
            }


            if (isValid)
            {
                Employee employee = new Employee();

                employee.SSN = int.Parse(textBoxSSN.Text);
                employee.Fname = textBoxFName.Text;
                employee.Lname = textBoxLName.Text;
                employee.Salary = int.Parse(textBoxSalary.Text);
                employee.Address = textBoxAdress.Text;

                DateTime birthDate = dateTimePickerBirthDate.Value;
                employee.Bdate = birthDate;

                int targetDepNum = (int)comboBoxDepartmentChoose.SelectedValue;
                employee.Department = DataAccessLayer.GetDepartment(targetDepNum);

                //employee.Department = BusinessLogicLayer.SearchDepartmentByID((int)comboBoxDepartmentChoose.SelectedValue);

                return employee;
            }
            else
            {
                return null;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            ErrorMsgCantUpdateSSN.Visible = false;
            textBoxSSN.Enabled = true;
            ErrorMsgRepeatedSSN.Visible = false;


            Employee employee = collectEmployeeDate();

            if (employee != null)
            {
                if (!DataAccessLayer.IsRepeatedSSN((int.Parse(textBoxSSN.Text))))
                {
                    ErrorMsgRepeatedSSN.Visible = false;

                    DataAccessLayer.AddEmployee(employee);

                    // then updating the list immediately not waiting for comboBoxDepartments_SelectedIndexChange
                    listBoxDepartmentsEmployees.DisplayMember = "fname";
                    listBoxDepartmentsEmployees.ValueMember = "SSN";

                    int selectedDeptNum = (int)comboBoxDepartments.SelectedValue;

                    listBoxDepartmentsEmployees.DataSource = DataAccessLayer.GetDepartmentEmployees(selectedDeptNum);
                }
                else
                {
                    ErrorMsgRepeatedSSN.Visible = true;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            ErrorMsgCantUpdateSSN.Visible = false;
            textBoxSSN.Enabled = true;
            ErrorMsgRepeatedSSN.Visible = false;

            int targetEmpSSN = (int)listBoxDepartmentsEmployees.SelectedValue;
            //int targetDepID = (int)comboBoxDepartments.SelectedValue;

            DataAccessLayer.DeleteEmployee(targetEmpSSN);

            // then updating the list immediately not waiting for comboBoxDepartments_SelectedIndexChange
            listBoxDepartmentsEmployees.DisplayMember = "fname";
            listBoxDepartmentsEmployees.ValueMember = "SSN";

            int selectedDeptNum = (int)comboBoxDepartments.SelectedValue;

            listBoxDepartmentsEmployees.DataSource = DataAccessLayer.GetDepartmentEmployees(selectedDeptNum);
        }

        private Employee collectUpdatedEmployeeDate()
        {
            SSNRequiredMesage.Visible = false;
            fNameRequiredMesage.Visible = false;
            LNameRequiredMesage.Visible = false;
            SalaryRequiredMesage.Visible = false;

            bool isValid = true;

            //if (textBoxSSN.Text == "")
            //{
            //    isValid = false;
            //    SSNRequiredMesage.Visible = true;
            //}


            if (textBoxFName.Text == "")
            {
                isValid = false;
                fNameRequiredMesage.Visible = true;
            }


            if (textBoxLName.Text == "")
            {
                isValid = false;
                LNameRequiredMesage.Visible = true;
            }


            if (textBoxSalary.Text == "")
            {
                isValid = false;
                SalaryRequiredMesage.Visible = true;
            }


            if (isValid)
            {
                Employee employee = new Employee();

                textBoxSSN.Enabled = false;
                //employee.SSN = int.Parse(textBoxSSN.Text);
                employee.SSN = (int)listBoxDepartmentsEmployees.SelectedValue;
                employee.Fname = textBoxFName.Text;
                employee.Lname = textBoxLName.Text;
                employee.Salary = int.Parse(textBoxSalary.Text);
                employee.Address = textBoxAdress.Text;

                DateTime birthDate = dateTimePickerBirthDate.Value;
                employee.Bdate = birthDate;

                int targetDepNum = (int)comboBoxDepartmentChoose.SelectedValue;
                employee.Department = DataAccessLayer.GetDepartment(targetDepNum);

                //employee.Department = BusinessLogicLayer.SearchDepartmentByID((int)comboBoxDepartmentChoose.SelectedValue);

                return employee;
            }
            else
            {
                return null;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ErrorMsgCantUpdateSSN.Visible = false;
            textBoxSSN.Enabled = true;
            ErrorMsgRepeatedSSN.Visible = false;

            int targetEmpSSN = (int)listBoxDepartmentsEmployees.SelectedValue;
            int targetDepID = (int)comboBoxDepartments.SelectedValue;

            Employee updatedEmployee = collectUpdatedEmployeeDate();

            if (updatedEmployee != null)
            {
                textBoxSSN.Text = targetEmpSSN.ToString();

                ErrorMsgCantUpdateSSN.Visible = true;

                DataAccessLayer.UpdateEmployee(targetEmpSSN, updatedEmployee, targetDepID);

                // then updating the list immediately not waiting for comboBoxDepartments_SelectedIndexChange
                listBoxDepartmentsEmployees.DisplayMember = "fname";
                listBoxDepartmentsEmployees.ValueMember = "SSN";

                int selectedDeptNum = (int)comboBoxDepartments.SelectedValue;

                listBoxDepartmentsEmployees.DataSource = DataAccessLayer.GetDepartmentEmployees(selectedDeptNum);
            }
        
    

        ////================================================================

        //// another Solution :

        //////delete first: 
        ////int targetEmpSSN = (int)listBoxDepartmentsEmployees.SelectedValue;
        ////int targetDepID = (int)comboBoxDepartments.SelectedValue;

        ////BusinessLogicLayer.DeleteEmployee(targetEmpSSN, targetDepID);

        //////then add new employee with the new values : 
    }

    private void listBoxDepartmentsEmployees_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _SSn = (int)listBoxDepartmentsEmployees.SelectedValue;

        Employee emp = DataAccessLayer.GetEmployee(_SSn);

        textBoxSSN.Text = emp.SSN.ToString();
        textBoxFName.Text = emp.Fname;
        textBoxLName.Text = emp.Lname;
        textBoxSalary.Text = emp.Salary.ToString();
        textBoxAdress.Text = emp.Address;

        dateTimePickerBirthDate.Value = emp.Bdate ?? DateTime.Now;

        comboBoxDepartmentChoose.SelectedItem = emp.Department;
    }
}
}
