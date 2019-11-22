﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using flexnitClassControl;

namespace flexnit
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void pbxUsername_Click(object sender, EventArgs e)
        {
            txtLoginUsername.Focus();
        }

        private void txtLoginUsername_Enter(object sender, EventArgs e)
        {
            if(txtLoginUsername.Text == "Username")
                txtLoginUsername.Text = "";
        }

        private void txtLoginUsername_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLoginUsername.Text))
            {
                txtLoginUsername.Text = "Username";
            }
        }

        private void pbxSenha_Click(object sender, EventArgs e)
        {
            txtLoginSenha.Focus();
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if(txtLoginSenha.Text == "Password")
            {
                txtLoginSenha.Text = "";
                txtLoginSenha.PasswordChar = '*';
            }
        }

        private void txtSenha_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLoginSenha.Text))
            {
                txtLoginSenha.PasswordChar -= '*';
                txtLoginSenha.Text = "Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string sqlLogin = "SELECT clientes(email_cliente, username_cliente, senha_cliente) WHERE login = @nomeUsuario";            //   MessageBox.Show("Aqui é o login!!!");

            //   MessageBox.Show("Aqui é o login!!!");
            if(txtLoginUsername.Text == "admin")
            {
                frmMenuAdmin formAdmin = new frmMenuAdmin();
                this.Hide();
                formAdmin.ShowDialog();
            }
            else if (!String.IsNullOrWhiteSpace(txtLoginUsername.Text) && txtLoginUsername.Text != "admin")
            {
                frmMenuUser formMenuUsuario = new frmMenuUser(txtLoginUsername.Text);
                this.Hide();
                formMenuUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Insira um usuário!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Activate();
            this.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Aqui é o cadastro!!!");
            frmCadastro formCadastro = new frmCadastro();
            this.Hide();
            formCadastro.ShowDialog();
            this.Activate();
            this.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja realmente sair?", "Saindo?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resp == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
