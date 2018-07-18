using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Webservices.Clases;
using System.Globalization;
namespace Webservices
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            btn1.Clicked += Btn1_Clicked;
		}

        private async void Btn1_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserManager manager = new UserManager();
                var res = await manager.GetUser();
                if (res != null)
                {
                    lstUsuarios.ItemsSource = res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void Promociones_item(object sender, ItemTappedEventArgs e)
        {
            CultureInfo dolar = new CultureInfo("en-US");
            var promocion = e.Item as User;
           await DisplayAlert("Promociones", "Nombre: " + promocion.Nombre + "\n" + "Marca: " +promocion.Marca+ 
               "\n" + "Contenido : " + promocion.Contenido+ " g/cm"+"\n"+"Valor: $"+promocion.Valor, "ok");
        }
    }
}
