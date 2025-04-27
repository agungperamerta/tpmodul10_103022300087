using tpmodul10_103022300087.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul10_103022300087.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Static list mahasiswa (default data anggota kelompok)
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa("Agung Peramerta", "103022300087"),
            new Mahasiswa("Intan", "103022330067"),
            new Mahasiswa("Fadhli Rabbi", "103022300055"),
            new Mahasiswa("Steven Gerald", "103022300155"),
            new Mahasiswa("Iqbal", "103022300146"),
            new Mahasiswa("Raihan Ananda", "103022330075"),
            new Mahasiswa("Gumilar Hari", "103022300137")
        };

        // GET: /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return Ok(daftarMahasiswa);
        }

        // GET: /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }
            return Ok(daftarMahasiswa[index]);
        }

        // POST: /api/mahasiswa
        [HttpPost]
        public ActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            daftarMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(GetByIndex), new { index = daftarMahasiswa.Count - 1 }, mahasiswa);
        }

        // DELETE: /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }

            daftarMahasiswa.RemoveAt(index);
            return NoContent();
        }
    }
}
