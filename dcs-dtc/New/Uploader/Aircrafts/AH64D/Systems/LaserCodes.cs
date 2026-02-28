using DTC.New.Presets.V2.Aircrafts.AH64D.Systems;
using DTC.New.Uploader.Base;
using System.Diagnostics;

namespace DTC.New.Uploader.Aircrafts.AH64D;

public partial class AH64DUploader
{

    private string mapLaserLetterToBtn(char letter)
    {
        if (letter == 'A') return "L1";
        if (letter == 'B') return "L2";
        if (letter == 'C') return "L3";
        if (letter == 'D') return "L4";
        if (letter == 'E') return "L5";
        if (letter == 'F') return "L6";
        
        if (letter == 'G') return "B2";
        if (letter == 'H') return "B3";
        if (letter == 'J') return "B4";
        if (letter == 'K') return "B5";

        if (letter == 'L') return "R6";
        if (letter == 'M') return "R5";
        if (letter == 'N') return "R4";
        if (letter == 'P') return "R3";
        if (letter == 'Q') return "R2";
        if (letter == 'R') return "R1";

        return "";
        
    }
    private void BuildLaserCodes(bool pilot)
    {
        if (!config.Upload.LaserCodes || config.LaserCodes == null)
        {
            return;
        }

        Device display = pilot ? MFD_PLT_RIGHT : MFD_CPG_RIGHT;
        Device keyboard = pilot ? KU_PILOT : KU_CPG;

        Cmd(display.GetCommand("WPN"));
        Cmd(display.GetCommand("T4"));
        Cmd(display.GetCommand("T5"));

        foreach (var letter in LaserCodesSystem.Letters)
        {
            var code = config.LaserCodes.GetCode(letter);
            if (string.IsNullOrEmpty(code) || code.Length != 4)
            {
                continue;
            }

            var key = mapLaserLetterToBtn(letter);
            if (key=="")
            {
                continue;
            }

            Cmd(display.GetCommand(key));
            Cmd(keyboard.GetCommand("CLR"));
            Cmd(Keyboard(keyboard, $"{code}"));
            Cmd(keyboard.GetCommand("ENTER"));
        }

        //Cmd(display.GetCommand("WPN"));*/
    }
}
