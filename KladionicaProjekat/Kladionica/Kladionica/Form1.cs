﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kladionica.data.dto;
using Kladionica.data.dao;
using Kladionica.data.dao.mysql;

namespace Kladionica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // dodavanje novog zaposlenog u bazu
            /*ZaposleniDTO zaposleni = new ZaposleniDTO();

            zaposleni.Ime = "Petar";
            zaposleni.Prezime = "Petrovic";
            zaposleni.BrojTelefona = "066123456";
            zaposleni.Adresa = "Ulica bb";
            zaposleni.Sifra = "123456";
            zaposleni.NivoPristupa = "Puni pristup";

            MySqlDAOFactory factory = new MySqlDAOFactory();
            int id = factory.getZaposleniDAO().insert(zaposleni);
            textBox1.Text = "" + id; */

            // logovanje zaposlenog
           /* string ime = textBox1.Text.ToString();
            string sifra = textBox2.Text.ToString();

            MySqlDAOFactory factory = new MySqlDAOFactory();
            ZaposleniDTO zaposleni = factory.getZaposleniDAO().getByImeISifra(ime, sifra);

            label1.Text = zaposleni.Prezime; */

            // dodavanje novog igraca u bazu
             /*IgracDTO igrac = new IgracDTO();

             igrac.Ime = "Petar";
             igrac.Prezime = "Petrovic";
             igrac.Sifra = "123456";

             MySqlDAOFactory factory = new MySqlDAOFactory();
             int id = factory.getIgracDAO().insert(igrac);
             textBox1.Text = "" + id; */

            // logovanje igraca
           /* string ime = textBox1.Text.ToString();
            string sifra = textBox2.Text.ToString();

            MySqlDAOFactory factory = new MySqlDAOFactory();
            IgracDTO igrac = factory.getIgracDAO().getByImeISifra(ime, sifra);

            label1.Text = igrac.Prezime; */

            // umetanje dogadjaja
            /*DogadjajDTO dogadjaj = new DogadjajDTO();
            dogadjaj.VrijemeOdrzavanja = new DateTime(2017, 3, 25, 16, 0, 0);
            dogadjaj.Par = new ParDTO();
            dogadjaj.Par.Id = 1;
            MySqlDAOFactory factory = new MySqlDAOFactory();
            factory.getDogadjajDAO().insert(dogadjaj);
            label1.Text = dogadjaj.VrijemeOdrzavanja.ToString(); */

            // svi validni dogadjaji
            /*List<DogadjajDTO> dogadjaji = new List<DogadjajDTO>(0);
            MySqlDAOFactory factory = new MySqlDAOFactory();
            dogadjaji = factory.getDogadjajDAO().getAllValidEvents();
            label1.Text = dogadjaji.ElementAt(0).Par.Naziv; */
        }
    }
}
