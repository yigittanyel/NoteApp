using NodeApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.Business.Services.Abstract
{
    public interface INoteService
    {
        Task<Note> GetNote(int id);
        Task<IEnumerable<Note>> GetNotes();
        Task AddNotes(Note entity);
        Task UpdateNote(Note entity);
        void DeleteNote(int id);
    }
}
