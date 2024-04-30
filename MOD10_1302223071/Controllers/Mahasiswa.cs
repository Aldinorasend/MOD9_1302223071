using Microsoft.AspNetCore.Mvc;

namespace MOD10_1302223071.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mahasiswa : ControllerBase
    {
        private static List<String> Course = new List<String> { "PBO", "KPL", "BD", "UX" };
        private static List<MahasiswaModel> arrMahasiswa = new List<MahasiswaModel>
        {
            new MahasiswaModel ("M Aldino", "1302223071" , Course,2021 ),
            new MahasiswaModel ("Harits Azfa", "1302223045", Course,2022 ),
            new MahasiswaModel ("Fajar Jelang", "1302223146" , Course, 2023),
            new MahasiswaModel ("M Ghifari", "1302220033" , Course,2020)
        };

        [HttpGet]
        public IEnumerable<MahasiswaModel> Get()
        {
            return arrMahasiswa;
        }

        [HttpGet("{id}")]
        public ActionResult<MahasiswaModel> Get(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            return arrMahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] MahasiswaModel mahasiswa)
        {
            arrMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { id = arrMahasiswa.IndexOf(mahasiswa) }, mahasiswa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= arrMahasiswa.Count)
            {
                return NotFound();
            }

            arrMahasiswa.RemoveAt(id);
            return NoContent();
        }
        public class MahasiswaModel
        {
            public string Nama { get; set; }
            public string Nim { get; set; }
            public List<String> Course { get; set; }
            public int Year { get; set; }
            public MahasiswaModel(string Nama, string Nim, List<String> Course, int Year) {
                
                this.Nama = Nama;
                this. Nim = Nim;  
                this. Course = Course;
                this.Year = Year;
            }
        }
    }
}
