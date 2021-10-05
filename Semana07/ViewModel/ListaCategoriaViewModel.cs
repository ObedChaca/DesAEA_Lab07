using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Semana07.View;

namespace Semana07.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {

        ObservableCollection<Categoria> _Categorias;
        //Cambios
        public ObservableCollection<Categoria> Categorias
        {
            get { return _Categorias; }
            set
            {
                if (_Categorias != value)
                {
                    _Categorias = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NuevoCommand { set; get; }
        public ICommand ConsultarCommand { set; get; }

        public ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );

            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = (new Model.CategoriaModel()).Categorias; }
                );

            void Abrir()
            {
                ManCategoria window = new ManCategoria();
                window.ShowDialog();
                //Categorias = (new Model.CategoriaModel()).Categorias;
            }
        }
    }
}
