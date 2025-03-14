using Integrador.Entities;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        InitializeComponent();

        Auto.AutoEliminado += mensaje => MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Persona.PersonaEliminada += mensaje => MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
