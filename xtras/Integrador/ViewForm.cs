using Integrador.Entities;

namespace Integrador;

public partial class ViewForm : Form
{
    private readonly ViewController _viewController;
    private readonly BindingSource _personaBindingSource = [];
    private readonly BindingSource _autosDePersonaBindingSource = [];

    public ViewForm()
    {
        InitializeComponent();
        _viewController = new ViewController();

        ConfigurarEnlaces();

        Auto.AutoEliminado += mensaje =>
        MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Persona.PersonaEliminada += mensaje =>
        MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        CargarPersonas();
        CargarAutos();
    }

    private void ConfigurarEnlaces()
    {
        try
        {
            // Enlazar los TextBox a las propiedades de Persona
            IdPersonaTextBox.DataBindings.Add("Text", _personaBindingSource, "Id");
            DniTextBox.DataBindings.Add("Text", _personaBindingSource, "DNI");
            NombreTextBox.DataBindings.Add("Text", _personaBindingSource, "Nombre");
            ApellidoTextBox.DataBindings.Add("Text", _personaBindingSource, "Apellido");

            // Enlazar la grilla de autos de la persona
            AutosDePersonaDataGridView.DataSource = _autosDePersonaBindingSource;
        }
        catch (Exception ex)
        {
            Service.LogError("Error al seleccionar una persona.", ex);
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Métodos para Personas.---------------------------------------------------
    private void CargarPersonas()
    {
        PersonasDataGridView.DataSource = _viewController.ObtenerPersonas();
    }

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (PersonasDataGridView.SelectedRows.Count > 0)
            {
                if (PersonasDataGridView.SelectedRows[0].DataBoundItem is Persona personaSeleccionada)
                {
                    _personaBindingSource.DataSource = personaSeleccionada;
                    _autosDePersonaBindingSource.DataSource = personaSeleccionada.Autos;
                    ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                }
            }
            else if (PersonasDataGridView.SelectedRows.Count == 0)
            {
                _personaBindingSource.DataSource = new Persona(); // Objeto vacío
                _autosDePersonaBindingSource.DataSource = new List<Auto>(); // Lista vacía
                ValorTotalAutosLabel.Text = "0,00 €";
            }
        }
        catch (Exception ex)
        {
            Service.LogError("Error al seleccionar una persona.", ex);
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            NuevoPersonaButton.Enabled = true;
        }
    }

    private void NuevoPersonaButton_Click(object sender, EventArgs e)
    {
        LimpiarPersona();
        NuevoPersonaButton.Enabled = false;
    }

    private void LimpiarPersona()
    {
        _personaBindingSource.DataSource = new Persona(); // Objeto vacío
        _autosDePersonaBindingSource.DataSource = null;
        ValorTotalAutosLabel.Text = "0,00 €";
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_personaBindingSource.Current is Persona personaSeleccionada)
            {
                personaSeleccionada.DNI = DniTextBox.Text;
                personaSeleccionada.Nombre = NombreTextBox.Text;
                personaSeleccionada.Apellido = ApellidoTextBox.Text;

                if (personaSeleccionada.Id == 0) // Nueva persona
                {
                    _viewController.CrearPersona(personaSeleccionada.DNI, personaSeleccionada.Nombre, personaSeleccionada.Apellido);
                }
                else // Persona existente
                {
                    _viewController.ActualizarPersona(personaSeleccionada);
                }

                LimpiarPersona();
                CargarPersonas();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            NuevoPersonaButton.Enabled = true;
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personaBindingSource.Current is Persona personaSeleccionada)
        {
            _viewController.EliminarPersona(personaSeleccionada);
            LimpiarPersona();
            CargarPersonas();
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
