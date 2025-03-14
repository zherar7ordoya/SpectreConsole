using Integrador.Entities;

namespace Integrador;

public partial class ViewForm : Form
{
    private readonly ViewController _viewController;

    public ViewForm()
    {
        InitializeComponent();
        _viewController = new ViewController();

        Auto.AutoEliminado += mensaje =>
        MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Persona.PersonaEliminada += mensaje =>
        MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        CargarPersonas();
        CargarAutos();
    }

    // Métodos para Personas.---------------------------------------------------
    private void CargarPersonas()
    {
        PersonasDataGridView.DataSource = _viewController.ObtenerPersonas();
    }

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (PersonasDataGridView.SelectedRows.Count > 0)
        {
            if (PersonasDataGridView.SelectedRows[0].DataBoundItem is Persona personaSeleccionada)
            {
                AutosDePersonaDataGridView.DataSource =
                    ViewController.ObtenerAutosDePersona(personaSeleccionada);
                ValorTotalAutosLabel.Text =
                    ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
            }
        }
    }

    private void PersonasDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (PersonasDataGridView.SelectedRows.Count > 0)
        {
            if (PersonasDataGridView.SelectedRows[0].DataBoundItem is Persona personaSeleccionada)
            {
                DniTextBox.Text = personaSeleccionada.DNI;
                NombreTextBox.Text = personaSeleccionada.Nombre;
                ApellidoTextBox.Text = personaSeleccionada.Apellido;
            }
        }
    }

    private void NuevoPersonaButton_Click(object sender, EventArgs e)
    {
        IdPersonaTextBox.Text = string.Empty;
        DniTextBox.Text = string.Empty;
        NombreTextBox.Text = string.Empty;
        ApellidoTextBox.Text = string.Empty;
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (IdPersonaTextBox.Text != string.Empty
                && PersonasDataGridView.SelectedRows[0].DataBoundItem is Persona personaSeleccionada)
            {
                personaSeleccionada.Id = int.Parse(IdPersonaTextBox.Text);
                personaSeleccionada.DNI = DniTextBox.Text;
                personaSeleccionada.Nombre = NombreTextBox.Text;
                personaSeleccionada.Apellido = ApellidoTextBox.Text;
                _viewController.ActualizarPersona(personaSeleccionada);
                CargarPersonas();
            }
            else
            {
                _viewController.CrearPersona(DniTextBox.Text, NombreTextBox.Text, ApellidoTextBox.Text);
                CargarPersonas();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        if (PersonasDataGridView.SelectedRows.Count > 0)
        {
            if (PersonasDataGridView.SelectedRows[0].DataBoundItem is Persona personaSeleccionada)
            {
                _viewController.EliminarPersona(personaSeleccionada);
                CargarPersonas();
            }
        }
    }



    // Métodos para Autos.------------------------------------------------------
    private void CargarAutos()
    {
        AutosDisponiblesDataGridView.DataSource = _viewController.ObtenerAutos();
    }


    // Métodos para Asignaciones.-----------------------------------------------
    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (PersonasDataGridView.SelectedRows.Count > 0
            && AutosDisponiblesDataGridView.SelectedRows.Count > 0)
        {
            if (PersonasDataGridView.SelectedRows[0].DataBoundItem is Persona personaSeleccionada
                && AutosDisponiblesDataGridView.SelectedRows[0].DataBoundItem is Auto autoSeleccionado)
            {
                ViewController.AsignarAutoAPersona(personaSeleccionada, autoSeleccionado);
                CargarAutos();
                CargarPersonas();
            }
        }
    }

    private void QuitarAutoButton_Click(object sender, EventArgs e)
    {
        if (PersonasDataGridView.SelectedRows.Count > 0
            && AutosDePersonaDataGridView.SelectedRows.Count > 0)
        {
            if (PersonasDataGridView.SelectedRows[0].DataBoundItem is Persona personaSeleccionada
                && AutosDePersonaDataGridView.SelectedRows[0].DataBoundItem is Auto autoSeleccionado)
            {
                ViewController.DesasignarAutoDePersona(personaSeleccionada, autoSeleccionado);
                CargarAutos();
                CargarPersonas();
            }
        }
    }
}
