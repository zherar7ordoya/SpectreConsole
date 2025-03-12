using Integrador.Entities;

namespace Integrador
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Auto.AutoEliminado += mensaje => MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Persona.PersonaEliminada += mensaje => MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
