using animek.Context;
using animek.Model;

namespace animek
{
    public partial class Form1 : Form
    {
        private AppDbContext context;
        public Form1()
        {
            InitializeComponent();
            context = new AppDbContext();
            var lines = File.ReadAllLines("animek_angolul.txt");

            var existingAnimes = new HashSet<string>(context.Animes.Select(a => $"{a.Animenev};{a.Ev};{a.Mufaj}"));
            foreach (var line in lines)
            {
                if (!existingAnimes.Contains(line))
                {
                    context.Animes.Add(new Anime
                    {
                        Animenev = line.Split(';')[0],
                        Ev = int.Parse(line.Split(';')[1]),
                        Mufaj = line.Split(';')[2]
                    });
                }
            }
            context.SaveChanges();
            loadData();
        }
        private void loadData()
        {
            dataGridView1.DataSource = context.Animes.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string query = textBox1.Text;
                var results = context.Animes.Where(a => a.Animenev.Contains(query.ToLower())).ToList();
                dataGridView1.DataSource = results;
            }
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            List<Anime> animes = new List<Anime>();
            animes.AddRange(context.Animes);
            dataGridView1.DataSource = animes.OrderBy(a => a.Ev).ToList();
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            Form2 ujAblak = new Form2();
            ujAblak.Text = "Anime Uj ablak";
            ujAblak.Show();
        }
    }
}
