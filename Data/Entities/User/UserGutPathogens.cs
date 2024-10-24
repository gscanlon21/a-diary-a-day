using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

/// <summary>
/// https://site-akiajqrf22xmaqzsiz6q.s3.amazonaws.com/DDI+Website/Sample+Reports/Sample+Report+GI360.pdf
/// </summary>
[Table("user_gut_pathogens")]
[Display(Name = "Pathogens", Description = "Most of what was screened for in your sample is typically present in the gut; it is just when it is at an elevated level that it can cause problems.")]
public class UserGutPathogens
{
    public class Consts
    {
        public const int BlastocystisMin = 0;
        public const int BlastocystisMax = 2;
        public const int BlastocystisStep = 1;

        public const int CampylobacterMin = 0;
        public const int CampylobacterMax = 2;
        public const int CampylobacterStep = 1;

        public const int ClostridioidesDifficileMin = 0;
        public const int ClostridioidesDifficileMax = 2;
        public const int ClostridioidesDifficileStep = 1;

        public const int CryptosporidiumMin = 0;
        public const int CryptosporidiumMax = 2;
        public const int CryptosporidiumStep = 1;

        public const int DientamoebaFragilisMin = 0;
        public const int DientamoebaFragilisMax = 2;
        public const int DientamoebaFragilisStep = 1;

        public const int EntamoebaHistolyticaMin = 0;
        public const int EntamoebaHistolyticaMax = 2;
        public const int EntamoebaHistolyticaStep = 1;

        public const int EscherichiaColiO157_H7Min = 0;
        public const int EscherichiaColiO157_H7Max = 2;
        public const int EscherichiaColiO157_H7Step = 1;

        public const int GiardiaIntestinalisMin = 0;
        public const int GiardiaIntestinalisMax = 2;
        public const int GiardiaIntestinalisStep = 1;

        public const int HelicobacterPyloriMin = 0;
        public const int HelicobacterPyloriMax = 2;
        public const int HelicobacterPyloriStep = 1;

        public const int SalmonellaEntericaMin = 0;
        public const int SalmonellaEntericaMax = 2;
        public const int SalmonellaEntericaStep = 1;

        public const int VibrioCholeraeMin = 0;
        public const int VibrioCholeraeMax = 2;
        public const int VibrioCholeraeStep = 1;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateOnly Date { get; init; } = DateHelpers.Today;

    [Range(0, 2)]
    [Display(Name = "Blastocystis", Description = "Blastocystis is a single celled eukaryote and is one of the most common intestinal parasites in humans worldwide.  Some species and strains under this genus can be more problematic than others; consult with your health-care provider if you have symptoms and a positive result. This parasite can cause GI symptoms but usually clears from the GI tract on its own. In cases when it does not, prescription pharmaceuticals from your doctor may be needed.")]
    public int? Blastocystis { get; set; }

    [Range(0, 2)]
    [Display(Name = "Campylobacter", Description = "Campylobacter is a bacterium that can cause campylobacteriosis, which can have symptoms that include diarrhea (sometimes bloody), abdominal pain, nausea, and vomiting. Symptoms typically last one week. Some infected persons have no symptoms at all.")]
    public int? Campylobacter { get; set; }

    [Range(0, 2)]
    [Display(Name = "Clostridioides difficile", Description = "C. difficile is a spore-forming bacterium and one of the most common causes of infection in the gut. Its symptoms include watery diarrhea, nausea, abdominal pain, and fever.")]
    public int? ClostridioidesDifficile { get; set; }

    [Range(0, 2)]
    [Display(Name = "Cryptosporidium", Description = "Cryptosporidium (&quot;Crypto&quot;) is a microscopic parasite. The most common symptom of infection (called cryptosporidiosis) is watery diarrhea. Other symptoms include abdominal pain, nausea, vomiting, and a fever lasting 1-4 weeks. And there can be no symptoms at all. Cryptosporidium is most commonly spread by swallowing contaminated water.")]
    public int? Cryptosporidium { get; set; }

    [Range(0, 2)]
    [Display(Name = "Dientamoeba fragilis", Description = "Dientamoeba fragilis is a protozoan parasite. Its symptoms typically include abdominal pain and diarrhea, but some with this parasite are asymptomatic too.")]
    public int? DientamoebaFragilis { get; set; }

    [Range(0, 2)]
    [Display(Name = "Entamoeba histolytica", Description = "Entamoeba histolytica is a parasitic amoeba. Only about 1 in 10 individuals with amebiasis (E. histolytica infection) develops symptoms, which, when present, are generally mild. Amoebic dysentery is a severe form of amebiasis and can produce abdominal pain, bloody stools, and fever.")]
    public int? EntamoebaHistolytica { get; set; }

    [Range(0, 2)]
    [Display(Name = "Escherichia coli O157:H7", Description = "Escherichia coli (E. coli) is a bacterium that is found in the environment and foods. Although most strains of E. coli are harmless, others can make you sick. E. coli 0157 can cause diarrhea, while others can cause urinary tract infections, respiratory illness and pneumonia, and other illnesses.")]
    public int? EscherichiaColiO157_H7 { get; set; }

    [Range(0, 2)]
    [Display(Name = "Giardia intestinalis", Description = "Giardia lamblia, also known as Giardia intestinalis, is a microscopic parasite that colonizes and reproduces in the small intestine. The symptoms of Giardia infection, or giardiasis, include fatigue, nausea, diarrhea, vomiting, weight loss, and abdominal cramps. Giardia is most commonly spread by swallowing contaminated water.")]
    public int? GiardiaIntestinalis { get; set; }

    [Range(0, 2)]
    [Display(Name = "Helicobacter pylori", Description = "Helicobacter pylori is a bacterium that infects the stomachs of about 60 percent of all adults worldwide. Infections are commonly acquired in childhood and are usually harmless. However, H. pylori infections are responsible for the majority of stomach and intestinal ulcers.")]
    public int? HelicobacterPylori { get; set; }

    [Range(0, 2)]
    [Display(Name = "Salmonella enterica", Description = "Salmonella enterica (typhi) is a foodborne pathogenic bacterium. A number of Salmonella varieties are serious human pathogens, causing gastroenteritis (inflammation of the gut and intestines), bacteremia (presence of bacteria in the blood), and enteric (typhoid) fever. Carriers can also be without symptoms.")]
    public int? SalmonellaEnterica { get; set; }

    [Range(0, 2)]
    [Display(Name = "Vibrio cholerae", Description = "Vibrio cholera is a bacterium naturally found in brackish water or saltwater. Some strains can cause the diarrheal disease cholera. Symptoms can be mild, but about 1 in 10 infected persons will have severe disease characterized by profuse watery diarrhea, vomiting, and leg cramps. Severe cholera can be fatal.")]
    public int? VibrioCholerae { get; set; }

    [NotMapped]
    public Dictionary<string, int?> Items => new()
    {
        { nameof(Blastocystis), Blastocystis },
        { nameof(Campylobacter), Campylobacter },
        { nameof(ClostridioidesDifficile), ClostridioidesDifficile },
        { nameof(Cryptosporidium), Cryptosporidium },
        { nameof(DientamoebaFragilis), DientamoebaFragilis },
        { nameof(EntamoebaHistolytica), EntamoebaHistolytica },
        { nameof(EscherichiaColiO157_H7), EscherichiaColiO157_H7 },
        { nameof(GiardiaIntestinalis), GiardiaIntestinalis },
        { nameof(HelicobacterPylori), HelicobacterPylori },
        { nameof(SalmonellaEnterica), SalmonellaEnterica },
        { nameof(VibrioCholerae), VibrioCholerae },
    };

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserGutPathogens))]
    public virtual User User { get; set; } = null!;
}
