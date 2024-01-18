using DTC.New.Presets.V2.Aircrafts.FA18.Systems;
using DTC.New.UI.Base.Systems;

namespace DTC.New.UI.Aircrafts.FA18.Systems;

public partial class SequencePage : AircraftSystemPage
{
    private SequenceSystem system;

    public SequencePage(FA18Page parent) : base(parent, nameof(parent.Configuration.Sequences))
    {
        InitializeComponent();

        this.system = parent.Configuration.Sequences;

        this.chkSeq1.Checked = system.EnableUpload1;
        this.chkSeq2.Checked = system.EnableUpload2;
        this.chkSeq3.Checked = system.EnableUpload3;

        this.chkSeq1.CheckedChanged += (sender, args) =>
        {
            this.system.EnableUpload1 = this.chkSeq1.Checked;
            this.UpdateVisibility();
            this.SavePreset();
        };
        this.chkSeq2.CheckedChanged += (sender, args) =>
        {
            this.system.EnableUpload2 = this.chkSeq2.Checked;
            this.UpdateVisibility();
            this.SavePreset();
        };
        this.chkSeq3.CheckedChanged += (sender, args) =>
        {
            this.system.EnableUpload3 = this.chkSeq3.Checked;
            this.UpdateVisibility();
            this.SavePreset();
        };

        pnlSeq1.LoadSequence(system.Seq1, this.SavePreset);
        pnlSeq2.LoadSequence(system.Seq2, this.SavePreset);
        pnlSeq3.LoadSequence(system.Seq3, this.SavePreset);

        this.UpdateVisibility();
    }

    public override string GetPageTitle()
    {
        return "Sequences";
    }

    private void UpdateVisibility()
    {
        this.pnlSeq1.Enabled = this.chkSeq1.Checked;
        this.pnlSeq2.Enabled = this.chkSeq2.Checked;
        this.pnlSeq3.Enabled = this.chkSeq3.Checked;
    }
}
