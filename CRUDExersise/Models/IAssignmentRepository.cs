using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public interface IAssignmentRepository
    {
        IEnumerable<Assignment> AllAssignments();
        Assignment GetAssignmentById(int assignmentId);
        IEnumerable<Assignment> GetAssignmentByName(string name);
        Assignment Update(Assignment updatedAssignment);
        Assignment Add(Assignment newAssignment);
        Assignment Delete(int assignmentId);
        int Commit();
    }
}
