﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CRUDExersise.Models
{
    public interface IAssignmentRepository
    {
        IEnumerable<Assignment> GetAllAssignments();
        Assignment GetAssignment(int clientId, int employeeId);
        List<Assignment> GetAssignmentsByClientId(int clientId);
        List<Assignment> GetAssignmentsByEmployeeId(int employeeId);
        Assignment Update(Assignment updatedAssignment);
        Assignment Add(Assignment newAssignment);
        Assignment Delete(int clientId, int employeeId);
        int Commit();
    }
}
