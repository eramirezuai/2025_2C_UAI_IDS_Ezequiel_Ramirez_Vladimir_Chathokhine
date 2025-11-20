using BLL;
using Framework.Services.Security.Credentials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormUserManagement : Form
    {
        private UserBLL userBLL;
        public FormUserManagement()
        {
            InitializeComponent();
            userBLL = new UserBLL();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formUserManagement_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            GetAllUsers();
            ConfigureDataGridView();
            


        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length>0&&txtPassword.Text.Length>0)
            {
                userBLL.CreateUser(txtUser.Text, txtPassword.Text);
                GetAllUsers();
            }
            else
            {
                MessageBox.Show("Username or password is not complete");
            }

        }

        private void GetAllUsers()
        {
            grdUsers.DataSource=null;
            //grdUsers.DataSource= userBLL.GetAllUsers();
            //List<User> user = userBLL.GetAllUsers();
            //grdUsers.DataSource = user;
            grdUsers.DataSource = userBLL.GetAllUsers().Select(u => new { u.Id, u.Name }).ToList();
        }

        private void ConfigureDataGridView()
        {
            // --- Bloquear modificaciones ---
            grdUsers.ReadOnly = true;                    // No permite editar celdas
            grdUsers.AllowUserToAddRows = false;         // No permite agregar filas manualmente
            grdUsers.AllowUserToDeleteRows = false;      // No permite borrar filas
            grdUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selecciona fila completa
            grdUsers.MultiSelect = false;                // Solo una fila a la vez
            grdUsers.EditMode = DataGridViewEditMode.EditProgrammatically; // Evita edición directa

            // --- Estilo visual ---
            grdUsers.BackgroundColor = Color.White;
            grdUsers.BorderStyle = BorderStyle.None;
            grdUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grdUsers.RowHeadersVisible = false;          // Oculta la columna de encabezado lateral

            // --- Encabezados ---
            grdUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            grdUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grdUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grdUsers.EnableHeadersVisualStyles = false;

            // --- Filas ---
            grdUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            grdUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215); // Azul Windows
            grdUsers.DefaultCellStyle.SelectionForeColor = Color.White;
            grdUsers.DefaultCellStyle.BackColor = Color.White;
            grdUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // --- Ajustes opcionales ---
            grdUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta columnas
            grdUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grdUsers.RowTemplate.Height = 28;

            //grdUsers.Columns["Password"].Visible = false;
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdUsers.CurrentRow != null)
                {
                    long id = Convert.ToInt64(grdUsers.CurrentRow.Cells["Id"].Value);
                    //MessageBox.Show($"ID seleccionado: {id}");
                    userBLL.DeleteUser(id);
                    GetAllUsers();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            //aca se llamaria a la bll para verificar que el user tiene la patente "User.Form"
            FormUserPermissions frm = new FormUserPermissions();
            //frm.IdUser = Convert.ToInt64(grdUsers.CurrentRow.Cells["Id"].Value);
            User user = new User();
            user.Name = Convert.ToString(grdUsers.CurrentRow.Cells["Name"].Value);
            user.Id = Convert.ToInt64(grdUsers.CurrentRow.Cells["Id"].Value);
            frm.baseUser = user;
            frm.ShowDialog();
        }
    }
}
