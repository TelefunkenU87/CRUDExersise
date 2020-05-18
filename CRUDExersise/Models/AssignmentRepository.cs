using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public class AssignmentRepository : IAssignmentRepository
    {
        public readonly AppDbContext _appDbContext;
        public AssignmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Assignment Add(Assignment newAssignment)
        {
            _appDbContext.Add(newAssignment);
            return newAssignment;
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public Assignment Delete(int clientId, int employeeId)
        {
            var assignment = GetAssignment(clientId, employeeId);
            if (assignment != null)
            {
                _appDbContext.Remove(assignment);
            }
            return assignment;
        }

        public IEnumerable<Assignment> GetAllAssignments()
        {
            return _appDbContext.Assignments;
        }

        public Assignment GetAssignment(int clientId, int employeeId)
        {
            return _appDbContext.Assignments.Find(clientId, employeeId);
        }

        public List<Assignment> GetAssignmentsByClientId(int clientId)
        {
            var assignments = _appDbContext.Assignments.Where(a => a.ClientId == clientId).ToList();
            return assignments;
        }

        public List<Assignment> GetAssignmentsByEmployeeId(int employeeId)
        {
            var assignments = _appDbContext.Assignments.Where(a => a.EmployeeId == employeeId).ToList();
            return assignments;
        }

        public Assignment Update(Assignment updatedAssignment)
        {
            var entity = _appDbContext.Attach(updatedAssignment);
            entity.State = EntityState.Modified;
            return updatedAssignment;
        }
    }
}
