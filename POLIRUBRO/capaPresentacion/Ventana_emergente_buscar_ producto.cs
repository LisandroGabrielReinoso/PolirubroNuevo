﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POLIRUBRO.capaNegocio;

namespace POLIRUBRO.capaPresentacion
{
    public partial class Ventana_emergente_buscar__producto : Form
    {
        public Ventana_emergente_buscar__producto()
        {
            InitializeComponent();
        }

        private void textBox_buscar_filtro_TextChanged(object sender, EventArgs e)
        {
            string opcion = comboBox1.SelectedItem.ToString();

            if (string.IsNullOrEmpty(opcion))
            {
                MessageBox.Show("Por favor, selecciona una opción.");
            }

            Facturacion_logica llevar = new Facturacion_logica();
            DataTable respuesta;

            string palabra_escrita = textBox_buscar_filtro.Text.Trim();
            string filtro;

            switch (opcion)
            {
                case "Categoria":
                    filtro = "Nombre_categoria";
                    respuesta = llevar.mostrar_productos_filtro(filtro, palabra_escrita);
                    Facturacion f = new Facturacion(respuesta);
                    break;

                case "Nombre":
                    filtro = "Nombre";
                    respuesta = llevar.mostrar_productos_filtro(filtro, palabra_escrita);
                    Facturacion f2 = new Facturacion(respuesta);
                    break;

                default:
                    return;
            }

                dvg_filtrado.DataSource = respuesta;
            dvg_filtrado.Columns["Codigo_barra"].Width = 130;
            dvg_filtrado.Columns["Fraccionable"].Width = 110;
        }


    }
}