using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingScheduler
{
    public partial class Form1 : Form
    {
        private List<Schedule> customerSchedule = new List<Schedule>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            /*// make it readonly
            //trainerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            testerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            vehicalComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            timeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;*/

            // trainercombo options
            trainerComboBox.Items.Add("Chris Humphrey");
            trainerComboBox.Items.Add("Patrick Humphrey");
            trainerComboBox.Items.Add("Ed Humphrey");
            trainerComboBox.Items.Add("Dave Skutt");
            trainerComboBox.Items.Add("Eddie Humphrey");
            trainerComboBox.Text = "Chris Humphrey";

            // testercombo options
            testerComboBox.Items.Add("Chris Humphrey");
            testerComboBox.Items.Add("Patrick Humphrey");
            testerComboBox.Items.Add("Ed Humphrey");
            testerComboBox.Items.Add("Dave Skutt");
            testerComboBox.Items.Add("Eddie Humphrey");
            testerComboBox.Text = "Patrick Humphrey";

            // vehicalcombo options
            vehicalComboBox.Items.Add("Semi Rental");
            vehicalComboBox.Items.Add("Truck Rental");
            vehicalComboBox.Items.Add("Customer Truck: Fifth Wheel");
            vehicalComboBox.Items.Add("Customer Truck: Pintle Hitch");
            vehicalComboBox.Items.Add("Customer Truck");
            vehicalComboBox.Items.Add("School Bus");
            vehicalComboBox.Items.Add("Transit/Coach");
            vehicalComboBox.Items.Add("Car Rental");
            vehicalComboBox.Items.Add("Customer's Car");
            vehicalComboBox.Text = "Semi Rental";

            //Lot options
            lotComboBox.Items.Add("Owosso");
            lotComboBox.Items.Add("Freeland");
            lotComboBox.Text = "Owosso";

            // cdlcombo options
            cdlComboBox.Items.Add("A");
            cdlComboBox.Items.Add("B");
            cdlComboBox.Items.Add("BP");
            cdlComboBox.Items.Add("BPS");
            cdlComboBox.Items.Add("C");
            cdlComboBox.Text = "A";

            // brakecombo options
            brakeComboBox.Items.Add("Hydraulic");
            brakeComboBox.Items.Add("Partial Air");
            brakeComboBox.Items.Add("Full Air");
            brakeComboBox.Text = "Full Air";

            // transcombo options
            transComboBox.Items.Add("Manual");
            transComboBox.Items.Add("Automatic");
            transComboBox.Text = "Manual";

            // timescombo options
            timeComboBox.Items.Add("8:00AM");
            timeComboBox.Items.Add("9:00AM");
            timeComboBox.Items.Add("10:00AM");
            timeComboBox.Items.Add("11:00AM");
            timeComboBox.Items.Add("12:00PM");
            timeComboBox.Items.Add("1:00PM");
            timeComboBox.Items.Add("2:00PM");
            timeComboBox.Items.Add("3:00PM");
            timeComboBox.Items.Add("4:00PM");
            timeComboBox.Items.Add("5:00PM");
            timeComboBox.Text = "9:00AM";

            // lengthcombo options
            lengthComboBox.Items.Add("1hrs");
            lengthComboBox.Items.Add("2hrs");
            lengthComboBox.Items.Add("3hrs");
            lengthComboBox.Items.Add("4hrs");
            lengthComboBox.Items.Add("5hrs");
            lengthComboBox.Items.Add("6hrs");
            lengthComboBox.Items.Add("7hrs");
            lengthComboBox.Items.Add("8hrs");
            lengthComboBox.Text = "4hrs";

            // lengthcombo options
            idComboBox.Items.Add("1");
            idComboBox.Text = "1";

            //UI Behavior Update. Bias towards car tests
            cdlComboBox.Visible = false;
            label10.Visible = false;
            transComboBox.Visible = false;
            label12.Visible = false;
            brakeComboBox.Visible = false;
            label11.Visible = false;
            lengthComboBox.Text = "1hrs";
            vehicalComboBox.Text = "Customer's Car";
        }


        /*ADD Training TO SCHEDULE BUTTON*/
        private void button2_Click(object sender, EventArgs e)
        {
            //create driver object
            Driver dObj = new Driver();
            dObj.first_name = firstTextBox.Text;
            dObj.last_name = lastTextBox.Text;
            dObj.trainer = trainerComboBox.Text;
            dObj.tester = testerComboBox.Text;
            dObj.vehical = vehicalComboBox.Text;
            dObj.trans = transComboBox.Text;
            dObj.brakes = brakeComboBox.Text;
            dObj.cdl = cdlComboBox.Text;
            dObj.setRate(dObj.vehical, false);

            //create schedule obj
            Schedule sObj = new Schedule();
            sObj.customer = dObj;
            sObj.date = dateTimePicker1.Value.ToShortDateString();
            sObj.time = timeComboBox.Text;
            sObj.id = idComboBox.Text;
            sObj.setHours(lengthComboBox.Text);
            sObj.type = "train";
            idComboBox.Items.Add((Int32.Parse(idComboBox.Text) + 1).ToString());
            idComboBox.Text = (Int32.Parse(idComboBox.Text) + 1).ToString();
            //add to list
            try
            {
                customerSchedule.Add(sObj);
            }
            catch
            {
                //do nothing
            }
            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }

        //test button clicked
        private void button5_Click(object sender, EventArgs e)
        {
            //create driver object
            Driver dObj = new Driver();
            dObj.first_name = firstTextBox.Text;
            dObj.last_name = lastTextBox.Text;
            dObj.trainer = trainerComboBox.Text;
            dObj.tester = testerComboBox.Text;
            dObj.vehical = vehicalComboBox.Text;
            dObj.trans = transComboBox.Text;
            dObj.brakes = brakeComboBox.Text;
            dObj.cdl = cdlComboBox.Text;
            dObj.setRate(dObj.vehical, false);

            //create schedule obj
            Schedule sObj = new Schedule();
            sObj.customer = dObj;
            sObj.date = dateTimePicker1.Value.ToShortDateString();
            sObj.time = timeComboBox.Text;
            sObj.id = idComboBox.Text;
            if (dObj.vehical != "Car Rental" && dObj.vehical != "Customer's Car"){
                sObj.setHours("3hrs");
            }
            else {
                sObj.setHours("1hrs");
            }
            
            sObj.type = "test";
            idComboBox.Items.Add((Int32.Parse(idComboBox.Text) + 1).ToString());
            idComboBox.Text = (Int32.Parse(idComboBox.Text) + 1).ToString();
            //add to list
            try
            {
                customerSchedule.Add(sObj);
            }
            catch
            {
                //do nothing
            }

            //go through and set rates
            for (int i = 0; i < customerSchedule.Count; i++)
            {
                customerSchedule[i].customer.setRate(vehicalComboBox.Text, false);
            }

            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }

        //RUNS WHEN REMOVE ID BUTTON CLICKED
        private void button1_Click(object sender, EventArgs e)
        {
            //make sure there are items to remove first
            if (idComboBox.Items.Count != 1)
            {
                //remove the item of specified ID
                int removeIndex = 0;
                int largest = 0;
                bool removable;
                List<string> ids = new List<string>();

                for (int i = 0; i < customerSchedule.Count; i++)
                {
                    if (customerSchedule[i].id == idComboBox.Text)
                    {
                        removeIndex = i;
                    }
                    else
                    {
                        ids.Add(customerSchedule[i].id);
                    }
                }
                customerSchedule.RemoveAt(removeIndex);

                //remove id number from combobox
                for (int i = 0; i < idComboBox.Items.Count; i++)
                {
                    if (idComboBox.GetItemText(idComboBox.Items[i]) == idComboBox.Text)
                    {
                        removeIndex = i;
                    }
                }
                idComboBox.Items.RemoveAt(removeIndex);

                //go through and find unused IDs, remove them too
                for (int i = 0; i < ids.Count; i++)
                {
                    removable = true;
                    for (int j = 0; j < idComboBox.Items.Count; j++)
                    {
                        if (ids[i] == idComboBox.GetItemText(idComboBox.Items[j]))
                        {
                            removable = false;
                        }
                    }
                    if (removable)
                    {
                        for (int k = 0; k < idComboBox.Items.Count; k++)
                        {
                            if ((idComboBox.GetItemText(idComboBox.Items[k]) == ids[i]) && ids[i] != largest.ToString())
                            {
                                idComboBox.Items.RemoveAt(k);
                            }
                        }
                    }
                }

                for (int i = 0; i < idComboBox.Items.Count; i++)
                {
                    if (Int32.Parse(idComboBox.GetItemText(idComboBox.Items[i])) > largest)
                    {
                        largest = Int32.Parse(idComboBox.GetItemText(idComboBox.Items[i]));
                    }
                }

                //new ID to set in idcombobox
                idComboBox.Text = largest.ToString();

                //print training in box and testing
                printTrainingToBox(customerSchedule);
                printTestingToBox(customerSchedule);
            }
        }

        private void printTestingToBox(List<Schedule> s)
        {
            bool testDate = false;
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].type == "test" ||s[i].type == "retest")
                {
                    testDate = true;
                }
            }
            if (!testDate)
            {
                return;
            }
            else
            {
                int total = 0;
                //print testing header
                richTextBox1.AppendText("\n\n\nTesting\n" + padString("ID", 5) + padString("Date", 20) + padString("Time", 15) + "\n");
                //print data for each testing session
                for (int i = 0; i < s.Count; i++)
                {
                    if (s[i].type == "test" || s[i].type == "retest") 
                    {
                        richTextBox1.AppendText(padString(s[i].id, 6) +
                            padString(s[i].date, 15) + padString(s[i].time, 12));
                        if (s[i].customer.tester == "Chris Humphrey")
                        {
                            richTextBox1.AppendText("w/Chris ");
                        }
                        else if (s[i].customer.tester == "Patrick Humphrey")
                        {
                            richTextBox1.AppendText("w/Pat ");
                        }
                        else if(s[i].customer.tester == "Dave Skutt")
                        {
                            richTextBox1.AppendText("w/Dave");
                        }
                        else if (s[i].customer.tester == "Ed Humphrey")
                        {
                            richTextBox1.AppendText("w/Ed ");
                        }
                        if (s[i].tentative == "Yes")
                        {
                            richTextBox1.AppendText(padString("(T)\n", 0));
                        }
                        else
                        {
                            richTextBox1.AppendText("\n");
                        }
                        total += s[i].customer.testingRate;
                    }
                }
                richTextBox1.AppendText("Testing Cost: $" + total);
            }
        }

        private void printTrainingToBox(List<Schedule> s)
        {
            int total = 0;
            richTextBox1.Clear();
            //print training header
            richTextBox1.AppendText("Training\n" + padString("ID", 5) +
                padString("Length", 11) + padString("Date", 20) + padString("Time", 15) + "\n");
            //print data for each training session
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].type == "train")
                {
                    richTextBox1.AppendText(padString(s[i].id, 6) + padString(s[i].hours, 14) +
                        padString(s[i].date, 15) + padString(s[i].time, 12));
                    if (s[i].customer.trainer == "Chris Humphrey")
                    {
                        richTextBox1.AppendText("w/Chris ");
                    }
                    else if (s[i].customer.trainer == "Patrick Humphrey")
                    {
                        richTextBox1.AppendText("w/Pat ");
                    }
                    else if (s[i].customer.trainer == "Ed Humphrey")
                    {
                        richTextBox1.AppendText("w/Ed ");
                    }
                    if (s[i].tentative == "Yes")
                    {
                        richTextBox1.AppendText(padString("(T)\n", 0));
                    }
                    else
                    {
                        richTextBox1.AppendText("\n");
                    }
                    total += s[i].hoursTrained * s[i].customer.trainingRate;
                }
            }
            richTextBox1.AppendText("Training Cost: $" + total);
        }

        public string padString(string s, int p)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count++;
            }
            p -= count;
            for (; p > 0; p--)
            {
                s += " ";
            }
            return s;
        }

        /// <summary>
        /// Send Button Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                button4.Enabled = false;
                createHTML();
                send newForm = new TrainingScheduler.send();
                newForm.Show();
                newForm.TopMost = true;
                button4.Enabled = true;
            }
        }

        /// <summary>
        /// HTML OUTPUT BUTTON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                button7.Enabled = false;
                createHTML();
                button7.Enabled = true;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //clear customerSchedule
            customerSchedule = new List<Schedule>();



            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }

        private void createHTML()
        {
           // try
           if (customerSchedule.Count == 0)
            {
                return;
            }
            {
                bool hasTest = false;
                int totalHours = 0;
                string filename;
                string output = "";
                Driver customer = customerSchedule[0].customer;
                filename = @".\confirmations\" + firstTextBox.Text + lastTextBox.Text + ".html";
                Globals.first = firstTextBox.Text;
                Globals.last = lastTextBox.Text;
                Globals.confirmationFile = filename;

                output += @"<!DOCTYPE html>
<html>
<head>
<style>
h1 {
    color: black;
    text-align: left;
    font-family: Helvetica;
    font-size: 30px
}
.dba {
    color: black;
    font-family: Helvetica;
    font-size: 15px;}
.hed{
color: black;
text-align: left;
font-family: Helvetica;
font-size: 11px;
}
.hed2{
color: left;
text-align: center;
font-family: bold Helvetica;
font-size: 13px;
}
.hed3{
color: black;
text-align: left;
font-family: bold Helvetica;
font-size: 15px;
}
.hed4{
color: black;
text-align: left;
font-family: Helvetica;
font-size: 13px;
text-transform: none;
}
p {
    font-family: Helvetica;
    font-size: 18px;
}
hr { 
    display: block;
    margin-top: 0.1em;
    margin-bottom: 0em;
    margin-left: auto;
    margin-right: auto;
    border-style: inset;
    border-width: 1px;
}
        body {
            font-family: Helvetica, sans;
            font-size: 18px;
            color: #333333;
            font-weight: normal;
            line-height: 1.2;
            width: 960px;
            margin: 0 auto;
            padding: 0;
        }
        
        li {
            list-style-type: none;
            display: inline-block;
        }
        .header {
            text-align: center;
            padding: 5px auto;
        }
        
        .title {
            text-align: center;
        }
        
        .title .span-text {
            font-size: 14px;
        }
        
        .address {
            padding-bottom: 10px;
            border-bottom: 3px solid #a5a5a5;
            text-align: center;
        }
        
        .cert {
            font-weight: bold;
            text-align: center;
            padding-bottom: 20px;
        }
        
        .cust_detail {
        /* No styles yet */
        }
        
        .cust_detail table td {
            text-align: left;
            padding-top: 5px;
            padding-bottom: 5px;
            width: 10%;
        }

        .schedule {
            padding-top: 10px;
           
        }
        
        .schedule h3 {
            padding-top: 10px;
            padding-bottom: 10px;
            border-bottom: 3px solid #a5a5a5;
            text-transform: uppercase;
            color: #3e3e3e;
        }
        
        .schedule table tr th {
            text-align: left;
            padding-top: 5px;
            padding-bottom: 5px;
            width: 20%;
        }
        
        .schedule table tr td {
            text-align: left;
            padding-top: 5px;
            padding-bottom: 5px;
            font-weight: normal;
            min-width: 150px;            
        }
        
        .summary {
            padding-top: 10px;
            padding-bottom: 5px;
        }
        
        .summary h3 {
            padding-top: 10px;
            padding-bottom: 10px;
            border-bottom: 3px solid #a5a5a5;
            text-transform: uppercase;
            color: #3e3e3e;
        }
        .summary h3 span {
            text-transform: none;
        }
        
        .summary table td {
            text-align: left;
            padding-top: 5px;
            padding-bottom: 5px;
            width: 10%;
        }
        </style>

</head>
<body>
<h1>Humphrey Driver Training and Testing <span class=" + "\"dba" + "\">" + "(DBA)</span></br><span class=" + "\"hed2" + "\">" + "Humphrey Enterprises, Inc.&nbsp&nbsp&nbsp&nbsp</span>" +
     "<span class=" + "\"hed2" + "\">" + "Office:&nbsp&nbsp</span><span class=" + "\"hed" + "\">" + "2089 Corunna Ave. Owosso MI, 48867&nbsp&nbsp&nbsp&nbsp&nbsp</span><span class=" + "\"hed2" + "\">" +
     "Phone:</span><span class=" + "\"hed" + "\">" + "&nbsp&nbsp989-723-7176</span></br><hr><span class=" + "\"hed3" + "\">";
                if (customer.vehical != "Customer's Car" && customer.vehical != "Car Rental")
                {
                    output += "Department of State Certification #P000422&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" +
       "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" +
       "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" +
       "&nbsp&nbsp</span></h1></br>";
                }
                else
                {
                    output += "Department of State Certification #P000421&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" +
     "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" +
     "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" +
     "&nbsp&nbsp</span></h1></br>";
                }
                output += " <p>" + "Customer: " + customer.first_name + " " + customer.last_name + "</br>";
                if (customer.vehical != "Customer's Car" && customer.vehical != "Car Rental")
                {
                    if (lotComboBox.Text == "Owosso")
                    {
                        output += "CDL Lot: 110 S. Delaney Rd. Owosso MI, 48867</br>";
                    }
                    else
                    {
                        output += "Lot: Tri-Area Trucking School, 6272 Midland Rd. (red building), Freeland MI</br>";
                    }
                }
                else
                {
                    if (lotComboBox.Text == "Owosso")
                    {
                        output += "Lot: 2089 Corunna Ave Owosso MI, 48867<br/>";
                    }
                    else
                    {
                        output += "Lot: Tri-Area Trucking School, 6272 Midland Rd. (red building), Freeland MI</br>";
                    }
                }
                if (customer.vehical != "Customer's Car" && customer.vehical != "Car Rental")
                {
                    output += "Vehical: " + customer.vehical + ", " + customer.trans + " Trans, " + customer.brakes + " Brakes <br/>";
                }
                else
                {
                    output += "Vehical: " + customer.vehical + "<br/>";
                }

                output += customer.restrictions(true);
                if (customer.vehical != "Customer's Car" && customer.vehical != "Car Rental")
                {
                    output += "Class: " + "CDL-" + customer.cdl + "</br>";
                }
                output += "Training Rate $" + customer.trainingRate + "/hr</br>";
                output += "Testing Rate $" + customer.testingRate + "</br>";
                output += "</p><div class=\"schedule\">" +
                @"<h3>Training Schedule</h3>
            <table>
                <tr>
                    <th>Date</th>
                    <th>Time</th>
                    <th>Length</th>
                    <th>Trainer</th>
                </tr>";


                for (int i = 0; i < customerSchedule.Count; i++)
                {
                    if (customerSchedule[i].type == "train")
                    {
                        output += "<tr>";
                        output += "<td>" + customerSchedule[i].date + "</td>" + "<td>" + customerSchedule[i].time + "</td>" + "<td>" + customerSchedule[i].hours + "</td>" + "<td>" + customerSchedule[i].customer.trainer + "</td>";
                        output += "</tr>";
                        totalHours += customerSchedule[i].hoursTrained;
                    }
                }
                output += "</table></br></br>";

                output += @"<h3>Testing Schedule</h3>
            <table>
                <tr>
                    <th>Date</th>
                    <th>Time</th>
                    <th>Length</th>
                    <th>Tester</th>
                </tr>";

                for (int i = 0; i < customerSchedule.Count; i++)
                {
                    if (customerSchedule[i].type == "test" || customerSchedule[i].type == "retest")
                    {
                        output += "<tr>";
                        output += "<td>" + customerSchedule[i].date + "</td>" + "<td>" + customerSchedule[i].time + "</td>" + "<td>" + customerSchedule[i].hours + "</td>" + "<td>" + customerSchedule[i].customer.tester + "</td>";
                        output += "</tr>";
                        hasTest = true;
                    }
                }
                output += "</table></br></br>";
                output += "<h3>Summary<span class=\"hed4\">&nbsp(Totals subject to change if deviating from this outline)</span></h3>";

                output += "<p>Training (" + totalHours + "hrs * $" + customer.trainingRate + "/hr) = $" + totalHours * customer.trainingRate + "<br/>";
                if (Globals.trainingDiscount > 0)
                {
                    output += "Training Discount = $" + Globals.trainingDiscount + "<br/>";
                }
                if (hasTest)
                {
                    output += "Test = $" + customer.testingRate + "<br/>";
                    if (Globals.testingDiscount > 0)
                    {
                        output += "Testing Discount = $" + Globals.testingDiscount + "<br/>";
                    }
                    output += "<br/>";
                    output += "Grand Total = $" + (((totalHours * customer.trainingRate) - Globals.trainingDiscount) + (customer.testingRate - Globals.testingDiscount));
                }
                else
                {
                    output += "Test = $" + "0" + "<br/><br/>";
                    output += "Grand Total = $" + (totalHours * customer.trainingRate);
                }
                output += @"</div></p>

</body>
</html>";

                System.IO.File.WriteAllText(filename, output);
                //System.Diagnostics.Process.Start(filename);
                SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(output);
                try
                {
                    doc.Save(@".\confirmations_pdf\" + Globals.first + Globals.last + ".pdf");
                }
                catch
                {

                }
                doc.Close();


                System.Diagnostics.Process.Start(filename);
            }
/*            catch
            {
                MessageBox.Show("Something went wrong :(");
            }*/
        }

        private bool valid()
        {
            //valid checks
            if (firstTextBox.Text == "" || lastTextBox.Text == "")
            {
                MessageBox.Show("Enter a valid name for Customer!");
                return false;
            }
            return true;
        }

        private void cdlComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            cdlComboBox.DroppedDown = true;
        }

        private void transComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            transComboBox.DroppedDown = true;
        }

        private void trainerComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            trainerComboBox.DroppedDown = true;
        }

        private void testerComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            testerComboBox.DroppedDown = true;
        }

        private void vehicalComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            vehicalComboBox.DroppedDown = true;
        }

        private void brakeComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            brakeComboBox.DroppedDown = true;
        }

        private void timeComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            timeComboBox.DroppedDown = true;
        }

        private void idComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            idComboBox.DroppedDown = true;
        }

        private void lengthComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            lengthComboBox.DroppedDown = true;
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker1.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void vehicalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vehicalComboBox.Text == "Car Rental" || vehicalComboBox.Text == "Customer's Car")
            {
                cdlComboBox.Visible = false;
                label10.Visible = false;
                transComboBox.Visible = false;
                label12.Visible = false;
                brakeComboBox.Visible = false;
                label11.Visible = false;
                lengthComboBox.Text = "1hrs";
            }
            else
            {
                cdlComboBox.Visible = true;
                label10.Visible = true;
                transComboBox.Visible = true;
                label12.Visible = true;
                brakeComboBox.Visible = true;
                label11.Visible = true;
                lengthComboBox.Text = "3hrs";
            }
        }

        //retest button clicked
        private void button6_Click(object sender, EventArgs e)
        {
            //create driver object
            Driver dObj = new Driver();
            dObj.first_name = firstTextBox.Text;
            dObj.last_name = lastTextBox.Text;
            dObj.trainer = trainerComboBox.Text;
            dObj.tester = testerComboBox.Text;
            dObj.vehical = vehicalComboBox.Text;
            dObj.trans = transComboBox.Text;
            dObj.brakes = brakeComboBox.Text;
            dObj.cdl = cdlComboBox.Text;
            dObj.setRate(dObj.vehical, true);

            //create schedule obj
            Schedule sObj = new Schedule();
            sObj.customer = dObj;
            sObj.date = dateTimePicker1.Value.ToShortDateString();
            sObj.time = timeComboBox.Text;
            sObj.id = idComboBox.Text;
            if (dObj.vehical != "Car Rental" && dObj.vehical != "Customer's Car")
            {
                sObj.setHours(timeComboBox.Text);
            }
            else
            {
                sObj.setHours("1hrs");
            }

            sObj.type = "retest";
            idComboBox.Items.Add((Int32.Parse(idComboBox.Text) + 1).ToString());
            idComboBox.Text = (Int32.Parse(idComboBox.Text) + 1).ToString();
            //add to list
            try
            {
                customerSchedule.Add(sObj);
            }
            catch
            {
                //do nothing
            }

            //go through and set rates
            for (int i = 0; i < customerSchedule.Count; i++)
            {
                customerSchedule[i].customer.setRate(vehicalComboBox.Text, true);
            }

            //print training in box and testing
            printTrainingToBox(customerSchedule);
            printTestingToBox(customerSchedule);
        }

        private void lotComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            lotComboBox.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            discount newForm = new TrainingScheduler.discount();
            newForm.Show();
            newForm.TopMost = true;
            button8.Enabled = true;
        }
    }
}