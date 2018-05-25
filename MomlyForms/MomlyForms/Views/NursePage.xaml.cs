using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MomlyForms.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MomlyForms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NursePage : ContentPage
	{
        private List<NurseAdvice> nurseAdvices = new List<NurseAdvice>();
		public NursePage ()
		{
			InitializeComponent ();
            InitializeNursingAdvices();
            headerList.ItemsSource = nurseAdvices;
            headerList.ItemTapped += HeaderList_ItemTapped;
		}

        private async void HeaderList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender != null)
            {
                await adviceLabel.FadeTo(0, 300);
                var advice = (NurseAdvice) e.Item;
                string text = advice.Content;
                adviceLabel.Text = text;
                await adviceLabel.FadeTo(1, 300);
            }
        }

        private void InitializeNursingAdvices()
        {
            nurseAdvices.Add(new NurseAdvice
            {
                Id = 1,
                Header = "Forbered dig",
                Content = "Sæt dig ind i amning ligesom du forbereder dig på fødslen"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 2,
                Header = "Rust dig",
                Content = "Positive forventninger er vigtige, men det er også godt at være forberedt, hvis det går hen og bliver svært. Det er en balancegang"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 3,
                Header = "Forbered din partner",
                Content = "Forventningsafstem med din partner. Amning er et fuldtidsjob 8 timer i døgnet i starten – og det er dit eneste job, indtil din mælkeproduktion er på plads og du har overskud til andet"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 4,
                Header = "Skærm jer",
                Content = "Sørg for gode omstændigheder for din ammeopstart ved at værne om jeres lille familie"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 5,
                Header = "Skærm baby",
                Content = "Hav ikke for mange besøgende, babyer sover, når der er besøg og afreagerer stimulien, når gæsterne er gået"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 6,
                Header = "Vid at det er okay, at baby græder",
                Content = "Babyer græder ved brystet. Det er et instinkt for at skabe tilknytning og nedløb. Det er ikke fordi barnet skælder ud. Så hav tillid til dit barn og dig selv indtil I får styr på teknikken"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 7,
                Header = "Husk søvnen",
                Content = "Sov når baby sover, ens viljestyrke og smertetærskel er bare højere, når man får sovet"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 8,
                Header = "Husk at spise",
                Content = "Spis morgenmad før klokken 8, og sørg for at få dine måltider. Gerne en muslibar til natamningen"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 9,
                Header = "Husk at drikke",
                Content = "Drik rigeligt i løbet af dagen. Hav en vandflaske ved sengen om natten"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 10,
                Header = "I dagene efter fødslen",
                Content = "Lad baby amme fra begge bryster minimum 20-45 minutter, minimum 8 gange i døgnet, gerne længere hvis baby ønsker og dine vorter kan holde til det"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 11,
                Header = "Lad baby blive ved brystet",
                Content = "Babyer holder pauser ved brystet for at samle kræfter og vente på nyt nedløb eller produktion. Misforstå ikke dette til søvn eller færdig amning. Så længe baby holder vakum er amningen igang"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 12,
                Header = "Lidt er nok i starten",
                Content = "Nyfødtes mavesæk er ikke større end en valnød, selvom du måske kun kan pumpe 5-10 ml, så kan det være rigeligt til at starte med"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 13,
                Header = "Giv brysterne ro",
                Content = "Ellers sørg for at dine brystvorter får ro ved at trøste dit barn på anden vis, eventuelt hos far"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 14,
                Header = "Overvej hjælpemidler",
                Content = "Balancer dit ammeønske op imod din formåen. Kan dine brystvorter ikke følge med i starten kan det være nødvendigt at aflaste med ammebrikker, sut eller flaske. Forsag ikke hjælpemidlerne – hvis det er dem, der kan redde din amning"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 15,
                Header = "Brug ammeskaller",
                Content = "Avent ammeskaller er guld værd til opsamling fra det modsatte bryst end det du ammer fra – så kan du eftermade fra skallen som en kop bagefter. Nogle gange er det lige det ekstra, der mætter baby og afløbet kan være med til at optimere din produktion og hindre brystbetændelse"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 16,
                Header = "Brug brystpumpe",
                Content = "Brystpumpen kan være god at have til at tage det værste tryk i starten, så baby bedre kan få fat og ikke skal arbejde for længe for at få dit nedløb"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 17,
                Header = "Brug en stor sut",
                Content = "Sutten giver en anden sutteteknik, som i sidste ende kan belaste dine vorter yderligere, men omvendt kan det være nødvendigt, hvis dit barn er meget oralt og har behov for at trøstesutte. I så fald, så spring de små sutter over og køb en stor 3-6 måneders sut, som kan nå dybere ind i ganen ligesom brystet"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 18,
                Header = "Undgå at vænne baby til flasken",
                Content = "Flaske-madning kan gøres langsomt, så baby ikke bliver vænnet til et hurtigt flow. Har du brug for at aflaste/supplere med flaske, så tjek Youtube for at efterligne brystets flow"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 19,
                Header = "Malk eventuelt ud",
                Content = "Når mælken er løbet til, skal brysterne have lov at spænde op, men også blive bløde igen. Bryster er bløde efter en amning, hvis de ikke bliver det kan det være nødvendigt at malke lidt ud i starten for at undgå knuder og brystbetændelse"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 20,
                Header = "Am fra samme bryst",
                Content = "Efter mælken er løbet til skal baby tilbydes samme bryst til dette føles helt tomt. Eventuelt med en bøvseperiode imellem. Skift kun over, hvis baby ikke mættes og du skal stimulere din produktion op"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 21,
                Header = "Husk bøvsepauser",
                Content = "Ligger baby og hakker efter brystet som en spætte, -sutter og slipper igen og igen – er det nok et tegn på, at der sidder en bøvs på tværs og baby ikke kan danne vakum. Bøvs baby og læg til samme bryst. Hvis baby bliver gal, er brystet nok tomt og det er tegn til, at baby har brug for det andet bryst"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id =22,
                Header = "Få produktionen op",
                Content = "Skift gerne mange gange ved lav produktion, da hvert nedløb giver en lille portion i modsatte bryst også selvom det lige er blevet tømt"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 23,
                Header = "Hvis det er nødvendigt \nat sætte produktionen ned",
                Content = "Ved overproduktion, gylp og gentagne brystbetændelser er blokamning fra samme side gentagne gange en hjælp til at nedsætte produktionen"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 24,
                Header = "Når mælken ændrer sig",
                Content = "Husk at mælken ændrer sig ved 2 uger og der kommer mere bøvs, mavekneb og gråd op til barnet er 5 uger. Vær opmærksom på om baby har brug for at blive lagt til samme bryst efter bøvs eller kort lur"
            });

            nurseAdvices.Add(new NurseAdvice
            {
                Id = 25,
                Header = "Ammelejr ved appetitspring",
                Content = "Ved 2 og 3 måneder er baby i et appetitspring og de fleste oplever, at baby spiser mere og føler måske ikke, at brysterne kan følge med. Men det er ikke noget en god omgang hud mod hud og ammelejr med friamning i sengen ikke kan klare"
            });

        }
    }
}