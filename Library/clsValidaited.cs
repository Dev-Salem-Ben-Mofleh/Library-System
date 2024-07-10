using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public class clsValidaited
    {

        private static bool _ValidatedNumber(char NumberValidated)
        {
            for (int i = 48; i < 58; i++)
            {
                if (NumberValidated == Convert.ToChar(i))
                    return true;
            }
            return false;
        }

        public static bool ValidatedTextNumber(ErrorProvider errorProvider1, Guna2TextBox text)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();

            for (int i = 0; i < text.Text.Length; i++)
            {
                if (!_ValidatedNumber(text.Text[i]))
                {

                    cancelEventArgs.Cancel = true;
                    text.Focus();
                    errorProvider1.SetError(text, "Just Enter Numbers");
                    return false;

                }
            }
            cancelEventArgs.Cancel = false;

            errorProvider1.SetError(text, "");
            return true;
        }
        public static bool ValidatedTextNumberText(ErrorProvider errorProvider1, TextBox text)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();

            for (int i = 0; i < text.Text.Length; i++)
            {
                if (!_ValidatedNumber(text.Text[i]))
                {

                    cancelEventArgs.Cancel = true;
                    text.Focus();
                    errorProvider1.SetError(text, "Just Enter Numbers");
                    return false;

                }
            }
            cancelEventArgs.Cancel = false;

            errorProvider1.SetError(text, "");
            return true;
        }

        public static bool ValditionAddAndUpdateBooks(ErrorProvider errorProvider1,
            Guna2TextBox Tital, Guna2TextBox ISBN, Guna2TextBox Price
            , NumericUpDown numeric)
        {

            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrWhiteSpace(Tital.Text))
            {
                e.Cancel = true;
                Tital.Focus();
                errorProvider1.SetError(Tital, " Should have Value");
                return false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Tital, "");

            }

            if (string.IsNullOrWhiteSpace(ISBN.Text))
            {
                e.Cancel = true;
                ISBN.Focus();
                errorProvider1.SetError(ISBN, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(ISBN, "");
            }

            if (string.IsNullOrWhiteSpace(Price.Text))
            {
                e.Cancel = true;
                Price.Focus();
                errorProvider1.SetError(Price, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Price, "");
            }

            if (numeric.Value == 0)
            {
                e.Cancel = true;
                numeric.Focus();
                errorProvider1.SetError(numeric, " Should have Value Bigger 0");
                return false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(numeric, "");

            }

            return true;

        }

        public static bool ValditionAddAndUpdateEmployees(ErrorProvider errorProvider1,
               Guna2TextBox FirstName, Guna2TextBox LastName, Guna2TextBox UserName,
                Guna2TextBox Salary, Guna2TextBox Enail, Guna2TextBox Passowrd,
                Guna2TextBox PhoneNumbar)
        {

            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrWhiteSpace(FirstName.Text))
            {
                e.Cancel = true;
                FirstName.Focus();
                errorProvider1.SetError(FirstName, " Should have Value");
                return false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(FirstName, "");

            }

            if (string.IsNullOrWhiteSpace(LastName.Text))
            {
                e.Cancel = true;
                LastName.Focus();
                errorProvider1.SetError(LastName, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(LastName, "");
            }

            if (string.IsNullOrWhiteSpace(UserName.Text))
            {
                e.Cancel = true;
                UserName.Focus();
                errorProvider1.SetError(UserName, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(UserName, "");
            }

            if (string.IsNullOrWhiteSpace(Salary.Text))
            {
                e.Cancel = true;
                Salary.Focus();
                errorProvider1.SetError(Salary, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Salary, "");
            }
            if (string.IsNullOrWhiteSpace(Enail.Text))
            {
                e.Cancel = true;
                Enail.Focus();
                errorProvider1.SetError(Enail, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Enail, "");
            }

            if (string.IsNullOrWhiteSpace(Passowrd.Text))
            {
                e.Cancel = true;
                Passowrd.Focus();
                errorProvider1.SetError(Passowrd, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Passowrd, "");
            }

            if (string.IsNullOrWhiteSpace(PhoneNumbar.Text))
            {
                e.Cancel = true;
                PhoneNumbar.Focus();
                errorProvider1.SetError(PhoneNumbar, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(PhoneNumbar, "");
            }


            return true;

        }
        public static bool ValditedAddAndUpdateAuthor(ErrorProvider errorProvider1,
            Guna2TextBox AuthorName)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            if (string.IsNullOrEmpty(AuthorName.Text))
            {
                cancelEventArgs.Cancel = true;
                AuthorName.Focus();
                errorProvider1.SetError(AuthorName, "You should fill");
                return false;
            }
            else
            {
                cancelEventArgs.Cancel = false;

                errorProvider1.SetError(AuthorName, "");
                return true;

            }

        }
        public static bool ValditedAddAndUpdateGener(ErrorProvider errorProvider1,
           Guna2TextBox GenerName)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            if (string.IsNullOrEmpty(GenerName.Text))
            {
                cancelEventArgs.Cancel = true;
                GenerName.Focus();
                errorProvider1.SetError(GenerName, "You should fill");
                return false;
            }
            else
            {
                cancelEventArgs.Cancel = false;

                errorProvider1.SetError(GenerName, "");
                return true;

            }

        }
        public static bool ValditionLogin(ErrorProvider errorProvider1,
               Guna2TextBox UserName, Guna2TextBox Passowrd)
        {

            CancelEventArgs e = new CancelEventArgs();

          
            if (string.IsNullOrWhiteSpace(UserName.Text))
            {
                e.Cancel = true;
                UserName.Focus();
                errorProvider1.SetError(UserName, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(UserName, "");
            }

            if (string.IsNullOrWhiteSpace(Passowrd.Text))
            {
                e.Cancel = true;
                Passowrd.Focus();
                errorProvider1.SetError(Passowrd, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Passowrd, "");
            }

               return true;

        }
        public static bool ValditionAddAndUpdateMembers(ErrorProvider errorProvider1,
               Guna2TextBox FirstName, Guna2TextBox LastName, Guna2TextBox UserName,
                Guna2TextBox Enail, Guna2TextBox Passowrd,
                Guna2TextBox PhoneNumbar)
        {

            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrWhiteSpace(FirstName.Text))
            {
                e.Cancel = true;
                FirstName.Focus();
                errorProvider1.SetError(FirstName, " Should have Value");
                return false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(FirstName, "");

            }

            if (string.IsNullOrWhiteSpace(LastName.Text))
            {
                e.Cancel = true;
                LastName.Focus();
                errorProvider1.SetError(LastName, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(LastName, "");
            }

            if (string.IsNullOrWhiteSpace(UserName.Text))
            {
                e.Cancel = true;
                UserName.Focus();
                errorProvider1.SetError(UserName, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(UserName, "");
            }

            
           
            if (string.IsNullOrWhiteSpace(Enail.Text))
            {
                e.Cancel = true;
                Enail.Focus();
                errorProvider1.SetError(Enail, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Enail, "");
            }

            if (string.IsNullOrWhiteSpace(Passowrd.Text))
            {
                e.Cancel = true;
                Passowrd.Focus();
                errorProvider1.SetError(Passowrd, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Passowrd, "");
            }

            if (string.IsNullOrWhiteSpace(PhoneNumbar.Text))
            {
                e.Cancel = true;
                PhoneNumbar.Focus();
                errorProvider1.SetError(PhoneNumbar, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(PhoneNumbar, "");
            }


            return true;

        }

        public static bool ValditionAddAndUpdateMember(ErrorProvider errorProvider1,
              TextBox FirstName, TextBox LastName, TextBox UserName,
               TextBox Enail, TextBox Passowrd,
               TextBox PhoneNumbar)
        {

            CancelEventArgs e = new CancelEventArgs();

            if (string.IsNullOrWhiteSpace(FirstName.Text))
            {
                e.Cancel = true;
                FirstName.Focus();
                errorProvider1.SetError(FirstName, " Should have Value");
                return false;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(FirstName, "");

            }

            if (string.IsNullOrWhiteSpace(LastName.Text))
            {
                e.Cancel = true;
                LastName.Focus();
                errorProvider1.SetError(LastName, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(LastName, "");
            }

            if (string.IsNullOrWhiteSpace(UserName.Text))
            {
                e.Cancel = true;
                UserName.Focus();
                errorProvider1.SetError(UserName, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(UserName, "");
            }



            if (string.IsNullOrWhiteSpace(Enail.Text))
            {
                e.Cancel = true;
                Enail.Focus();
                errorProvider1.SetError(Enail, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Enail, "");
            }

            if (string.IsNullOrWhiteSpace(Passowrd.Text))
            {
                e.Cancel = true;
                Passowrd.Focus();
                errorProvider1.SetError(Passowrd, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Passowrd, "");
            }

            if (string.IsNullOrWhiteSpace(PhoneNumbar.Text))
            {
                e.Cancel = true;
                PhoneNumbar.Focus();
                errorProvider1.SetError(PhoneNumbar, " Should have Value");
                return false;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(PhoneNumbar, "");
            }


            return true;

        }




    }
}
