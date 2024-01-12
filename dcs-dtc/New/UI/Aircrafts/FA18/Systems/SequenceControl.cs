using DTC.New.Presets.V2.Aircrafts.FA18.Systems;

namespace DTC.New.UI.Aircrafts.FA18.Systems;

public partial class SequenceControl : UserControl
{
    private Action saveCallback;
    private bool loading = false;

    public SequenceControl()
    {
        InitializeComponent();
    }

    public void LoadSequence(Sequence seq, Action saveCallback)
    {
        this.InternalLoad(seq);

        this.saveCallback = saveCallback;

        this.radAll.CheckedChanged += (sender, args) => this.SaveSequence(seq);
        this.radRange.CheckedChanged += (sender, args) => this.SaveSequence(seq);
        this.radSpecific.CheckedChanged += (sender, args) => this.SaveSequence(seq);

        this.txtFrom.TextBoxChanged += (sender) => this.SaveSequence(seq);
        this.txtTo.TextBoxChanged += (sender) => this.SaveSequence(seq);
        this.txtWpts.LostFocus += (sender, args) => this.SaveSequence(seq);
    }

    private void SaveSequence(Sequence seq)
    {
        if (this.loading) return;

        seq.Waypoints = null;

        if (this.radAll.Checked)
        {
            seq.Mode = SequenceMode.UseAll;
        }
        else if (this.radRange.Checked)
        {
            seq.Mode = SequenceMode.UseRange;

            if (this.txtFrom.Value != null)
            {
                seq.Waypoints = new() { (int)this.txtFrom.Value };
                if (this.txtTo.Value != null)
                {
                    seq.Waypoints.Add((int)this.txtTo.Value);
                }
            }
            else
            {
                this.txtTo.Value = null;
            }
        }
        else if (this.radSpecific.Checked)
        {
            seq.Mode = SequenceMode.UseSpecific;
            if (!string.IsNullOrEmpty(this.txtWpts.Text))
            {
                var list = new List<int>();
                var arr = this.txtWpts.Text.Split(',');
                if (arr.Length > 0)
                {
                    foreach (var item in arr)
                    {
                        if (int.TryParse(item.Trim(), out int n))
                        {
                            if (!list.Contains(n)) list.Add(n);
                        }
                    }
                    if (list.Count > 0)
                    {
                        seq.Waypoints = list;
                    }
                }
            }
        }

        this.saveCallback();

        this.InternalLoad(seq);
    }

    private void InternalLoad(Sequence seq)
    {
        this.loading = true;

        this.radAll.Checked = seq.Mode == SequenceMode.UseAll;
        this.radRange.Checked = seq.Mode == SequenceMode.UseRange;
        this.radSpecific.Checked = seq.Mode == SequenceMode.UseSpecific;

        txtFrom.Value = null;
        txtTo.Value = null;

        if (seq.Mode == SequenceMode.UseRange && seq.Waypoints?.Count > 0)
        {
            txtFrom.Value = seq.Waypoints[0];
            if (seq.Waypoints.Count > 1)
            {
                txtTo.Value = seq.Waypoints[1];
            }
        }

        this.txtFrom.Enabled = seq.Mode == SequenceMode.UseRange;
        this.txtTo.Enabled = txtFrom.Value != null;

        this.txtWpts.Text = "";

        if (seq.Mode == SequenceMode.UseSpecific && seq.Waypoints?.Count > 0)
        {
            this.txtWpts.Text = string.Join(",", seq.Waypoints);
        }

        this.txtWpts.Enabled = seq.Mode == SequenceMode.UseSpecific;

        this.loading = false;
    }
}
