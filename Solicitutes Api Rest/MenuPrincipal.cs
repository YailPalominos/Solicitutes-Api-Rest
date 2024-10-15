using Newtonsoft.Json;
using SolicitudTerremotosUSGS;

namespace Solicitutes_Api_Rest
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private async void tipoCambioBoton_Click(object sender, EventArgs e)
        {
            this.resultado.Text = "Cargando";
            this.resultado.Text = await SolicitadorTerremotos.RealizarSolicitud();
        }
    }
}
