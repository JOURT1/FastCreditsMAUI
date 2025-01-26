using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JhoelSuarezPruebaProg2.Models;
using JhoelSuarezPruebaProg2.Repositories;
using System.IO;
using System.Collections.Generic;

namespace JhoelSuarezPruebaProg2.ViewModels
{
    public class ReporteViewModel : INotifyPropertyChanged
    {
        private readonly JSuarezUsuarioRepository _usuarioRepository;
        private readonly JsuarezCarroRepository _carroRepository;
        private readonly JsuarezCivilRepository _civilRepository;
        private readonly JsuarezLegalRepository _legalRepository;
        private JSuarezDatosCombinados _datosCombinados;

        public JSuarezDatosCombinados DatosCombinados
        {
            get => _datosCombinados;
            set
            {
                _datosCombinados = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerarReporteCommand { get; }

        public ReporteViewModel()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "JhoelSuarez.db3");
            _usuarioRepository = new JSuarezUsuarioRepository(dbPath);
            _carroRepository = new JsuarezCarroRepository(dbPath);
            _civilRepository = new JsuarezCivilRepository(dbPath);
            _legalRepository = new JsuarezLegalRepository(dbPath);
            GenerarReporteCommand = new Command<string>(OnGenerarReporte);
        }

        private void OnGenerarReporte(string cedula)
        {
            var usuario = _usuarioRepository.DevulveInfoUsuario(cedula);
            var carros = _carroRepository.DevulveCarrosPorCedula(cedula);
            var civiles = _civilRepository.DevulveCivilesPorCedula(cedula);
            var legales = _legalRepository.DevulveLegalesPorCedula(cedula);
            if (usuario != null)
            {
                DatosCombinados = new JSuarezDatosCombinados
                {
                    Usuario = usuario,
                    Carros = carros.ToList(),
                    Civiles = civiles.ToList(),
                    Legales = legales.ToList()
                };
            }
            else
            {
                DatosCombinados = null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

