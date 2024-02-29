using Ej2RickMortyAPI.Dtos;
using Ej2RickMortyAPI.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ej2RickMortyAPI.ViewModels
{
    public class RickMortyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand MostrarCommand{ get; set; }
        public List<Character> CharacterList { get; set; }
        public Character Character { get; set; }
        public string Conectividad { get; set; } = "";
        RickMortyAPI _api;
        public void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public RickMortyViewModel()
        {
            llenarCharacters();
            
            MostrarCommand = new AsyncCommand<int>(Mostrar);
            
        }

        private async Task llenarCharacters()
        {
            NetworkAccess accessType = Connectivity.Current.NetworkAccess;
            if (accessType == NetworkAccess.Internet)
            {
            _api = new RickMortyAPI();
            CharacterList = await _api.GetCharacters();
            OnPropertyChanged(nameof(CharacterList));
            }
            else
            {
                Conectividad = "No hay conexion";
            }
        }
        public async Task Mostrar(int id)
        {
            Character = await _api.GetCharacter(id);
            OnPropertyChanged(nameof(Character));
        }
      
       

    }
   
 }
