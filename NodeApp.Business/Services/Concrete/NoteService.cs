using NodeApp.Business.Services.Abstract;
using NodeApp.DataAccess.Repositories.Abstract;
using NodeApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeApp.Business.Services.Concrete
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> GetNote(int id)
        {
            return await _noteRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await _noteRepository.GetAllAsync();
        }

        public async Task AddNotes(Note entity)
        {
            await _noteRepository.AddAsync(entity);
        }

        public async Task UpdateNote(Note entity)
        {
            await _noteRepository.UpdateAsync(entity);
        }

        public void DeleteNote(int id)
        {
            _noteRepository.DeleteAsync(id);
        }
    }
}
