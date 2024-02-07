using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Presets.V2.Base.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.AH64D.Systems
{
    public partial class WaypointEditPanel : UserControl, IWaypointEditCustomPanel
    {
        private readonly PointType[] allowedPointTypes;
        private Identifier[] idents;

        public WaypointEditPanel(params PointType[] allowedPointTypes)
        {
            InitializeComponent();

            foreach (var type in allowedPointTypes)
            {
                cboPointTypes.Items.Add(type);
            }

            this.allowedPointTypes = allowedPointTypes;
        }

        public Control GetControl()
        {
            return this;
        }

        public void LoadWaypoint(IWaypoint wpt)
        {
            var w = (Waypoint)wpt;
            if (!string.IsNullOrEmpty(w.PointType))
            {
                cboPointTypes.SelectedItem = allowedPointTypes.Where(x => x.Code == w.PointType).First();
                if (!string.IsNullOrEmpty(w.Identifier))
                {
                    cboIdentifier.SelectedItem = idents.Where(x => x.Code == w.Identifier).First();
                }
            }
            txtFree.Text = w.Free;
        }

        public void Save(IWaypoint wpt)
        {
            var w = (Waypoint)wpt;
            w.PointType = ((PointType)cboPointTypes.SelectedItem).Code;
            w.Identifier = ((Identifier)cboIdentifier.SelectedItem).Code;
            w.Free = txtFree.Text.ToUpper();
        }

        public bool Validate(out string? message)
        {
            if (cboPointTypes.SelectedItem == null)
            {
                message = "Select a point type";
                return false;
            }
            if (cboIdentifier.SelectedItem == null)
            {
                message = "Select an identifier";
                return false;
            }

            message = null;
            return true;
        }

        private void cboPointTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboIdentifier.Items.Clear();
            if (cboPointTypes.SelectedItem != null)
            {
                this.idents = Identifiers.GetIdentifiers((PointType)cboPointTypes.SelectedItem);
                foreach (var ident in idents)
                {
                    cboIdentifier.Items.Add(ident);
                }
            }
        }
    }
}
