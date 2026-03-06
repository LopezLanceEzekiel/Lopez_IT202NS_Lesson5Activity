using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoryActivity5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void QualifiedDependentsStatus_Txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void GROSSINCOME_button_Click(object sender, EventArgs e)
        {
            // a. Basic Income
            double.TryParse(BI_RateHour_Txtbox.Text, out double biRate);
            double.TryParse(BI_NoofHoursCutOff_Txtbox.Text, out double biHours);
            double basicIncome = biRate * biHours;
            BI_IncomeCutOff_Txtbox.Text = basicIncome.ToString("N2");

            // b. Honorarium Income
            double.TryParse(HI_RateHour_Txtbox.Text, out double honRate);
            double.TryParse(HI_NoofHoursCutOff_Txtbox.Text, out double honHours);
            double honIncome = honRate * honHours;
            HI_IncomeCutOff_Txtbox.Text = honIncome.ToString("N2");

            // c. Other Income
            double.TryParse(OI_RateHour_Txtbox.Text, out double othRate);
            double.TryParse(OI_NoofHoursCutOff_Txtbox.Text, out double othHours);
            double otherIncome = othRate * othHours;
            OI_IncomeCutOff_Txtbox.Text = otherIncome.ToString("N2");

            // d. Gross Income
            double grossIncome = basicIncome + honIncome + otherIncome;
            GROSSINCOME_Txtbox.Text = grossIncome.ToString("N2");

            // e. Regular Deductions
            PagIbigContribution_Txtbox.Text = "200.00"; // Fixed amount

            // Logic for mandated amounts (Example: 5% SSS, 2% PhilHealth, 10% Tax)
            SSSContribution_Txtbox.Text = (grossIncome * 0.05).ToString("N2");
            PhilhealthContribution_Txtbox.Text = (grossIncome * 0.02).ToString("N2");
            IncomeTaxContribution_Txtbox.Text = (grossIncome * 0.10).ToString("N2");
        }

        private void NETINCOME_button_Click(object sender, EventArgs e)
        {
            // f. Total Deductions
            double.TryParse(SSSContribution_Txtbox.Text, out double sssReg);
            double.TryParse(PhilhealthContribution_Txtbox.Text, out double philReg);
            double.TryParse(PagIbigContribution_Txtbox.Text, out double piReg);
            double.TryParse(IncomeTaxContribution_Txtbox.Text, out double taxReg);

            // Get Other Deductions (User Input)
            double.TryParse(SSSLoan_Txtbox.Text, out double sssLoan);
            double.TryParse(PagibigLoan_Txtbox.Text, out double piLoan);
            double.TryParse(FacultySavingsDeposit_Txtbox.Text, out double facSaveDep);
            double.TryParse(FacultySavingsLoan_Txtbox.Text, out double facSaveLoan);
            double.TryParse(SafetyLoan_Txtbox.Text, out double safetyLoan);

            double totalDeductions = sssReg + philReg + piReg + taxReg +
                                    sssLoan + piLoan + facSaveDep + facSaveLoan + safetyLoan;

            TOTALDEDUCTION_Txtbox.Text = totalDeductions.ToString("N2");

            // g. Net Income
            double.TryParse(GROSSINCOME_Txtbox.Text, out double gross);
            double netIncome = gross - totalDeductions;
            NETINCOME_Txtbox.Text = netIncome.ToString("N2");
        }

        private void NEW_button_Click(object sender, EventArgs e)
        {
            // Loops through all controls directly on the form
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                }
            }
        }

        private void SAVE_button_Click(object sender, EventArgs e)
        {
            // 1. Combine Name
            string fullName = $"{Firstname_Txtbox.Text} {Middlename_Txtbox.Text} {Surname_Txtbox.Text}";

            // 2. Fixed Values from Manual
            string company = "Lyceum of the Philippines University Cavite";
            double sssWisp = 750.00;
            int adjustment = 0;
            int substitution = 0;
            int tardy = 0;

            // 3. Construct the Payslip Report string
            // Using string interpolation ($) to include variables
            string payslip = $"COMPANY: {company}\n" +
                             $"--------------------------------------------------\n" +
                             $"Employee Code: {EmployeeNumber_Txtbox.Text}\n" +
                             $"Employee Name: {fullName}\n" +
                             $"Department: {Department_Txtbox.Text}\n" +
                             $"Pay Period: {Paydate_Txtbox.Text}\n" +
                             $"--------------------------------------------------\n" +
                             $"EARNINGS:\n" +
                             $"Basic Pay: {BI_IncomeCutOff_Txtbox.Text}\n" +
                             $"Honorarium: {HI_IncomeCutOff_Txtbox.Text}\n" +
                             $"Overtime (Other): {OI_IncomeCutOff_Txtbox.Text}\n" +
                             $"Honorarium Adjustment: {adjustment}\n" +
                             $"Substitution: {substitution}\n" +
                             $"Tardy: {tardy}\n" +
                             $"--------------------------------------------------\n" +
                             $"DEDUCTIONS:\n" +
                             $"SSS: {SSSContribution_Txtbox.Text}\n" +
                             $"PhilHealth: {PhilhealthContribution_Txtbox.Text}\n" +
                             $"Withholding Tax: {IncomeTaxContribution_Txtbox.Text}\n" +
                             $"HDMF (Pag-IBIG): {PagIbigContribution_Txtbox.Text}\n" +
                             $"SSS WISP: {sssWisp:N2}\n" +
                             $"--------------------------------------------------\n" +
                             $"NET PAY: {NETINCOME_Txtbox.Text}";

            // 4. Display the Report
            MessageBox.Show(payslip, "PAYSLIP REPORT");
        }
    }
    
}
