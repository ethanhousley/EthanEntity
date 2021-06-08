using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EthanEntity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)                    //SEARCH
        {
            using (FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {
                

                int U = int.Parse(txtUserIdBx.Text);
                var searchUser = _dbContext.PrimaryUsers.First(x => x.UserID == U);
                txtUserIdBx.Text = searchUser.UserID.ToString();
                txtCityBx.Text = searchUser.City;
                txtStateBx.Text = searchUser.State;
                txtZipBx.Text = searchUser.Zip.ToString();
                
                MessageBox.Show("User Found.");
            
            }
        }

        private void btnSave_Click(object sender, EventArgs e)                  //SAVE
        {
            using (FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {

                if (ValidateField())                    //Validation
                {

                    var newUser = new PrimaryUser();
                    newUser.UserID = Int32.Parse(txtUserIdBx.Text);
                    newUser.State = txtStateBx.Text;
                    newUser.City = txtCityBx.Text;
                    newUser.Zip = Int32.Parse(txtZipBx.Text);


                    _dbContext.PrimaryUsers.Add(newUser);
                    _dbContext.SaveChanges();
                    MessageBox.Show("Changes Saved");
                }

                else
                {
                    MessageBox.Show("Please enter a UserID value.");
                }
            }        
        }

        private void btnUpdate_Click(object sender, EventArgs e)                //UPDATE
        {

            using (FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {

                var upUser = new PrimaryUser();
                upUser.UserID = Int32.Parse(txtUserIdBx.Text);
                upUser.State = txtStateBx.Text;
                upUser.City = txtCityBx.Text;
                upUser.Zip = Int32.Parse(txtZipBx.Text);
                
               
                _dbContext.Entry(upUser).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                MessageBox.Show("User Updated.");
            
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)                    //DELETE
        {
            using (FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {

                int U = int.Parse(txtUserIdBx.Text);
                var delUser = _dbContext.PrimaryUsers.First(x => x.UserID == U);


                _dbContext.PrimaryUsers.Remove(delUser);
                _dbContext.SaveChanges();
                MessageBox.Show("User Successfully Deleted.");
          
            }
        }

        public bool ValidateField()                 //ValidationMethod
        {
         
            if (string.IsNullOrEmpty(txtUserIdBx.Text))
            {

                return false;
            }

            return true;
        }
    }


}
