﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCEP.Servico.Modelo;
using App01_ConsultaCEP.Servico;

namespace App01_ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //Toda Logica do programa

            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
                try
                {
                    Endereco end = ViaCEPservico.BuscarEnderecoViaCEP(cep);

                    if (end != null) 
                    {
                        RESULTADO.Text = string.Format("Endereco: {0} - {1}, {2} - {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                          
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }

        }
        private bool isValidCEP(string cep)
        {
                bool valido = true;

                if (cep.Length !=8)
                {
                    DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");
                    
                    valido = false;
                }
                int NovoCEP = 0;
                if(!int.TryParse(cep, out NovoCEP))
                {
                    DisplayAlert("ERRO", "CEP Inválido! O CEP deve deve ser composto apenas por numeros.", "OK");
                    valido = false;
                }

                return valido;

        }
    }
}
