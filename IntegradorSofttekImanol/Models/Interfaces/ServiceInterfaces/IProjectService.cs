﻿using IntegradorSofttekImanol.Models.DTOs.Proyecto;
using System.Linq.Expressions;

namespace IntegradorSofttekImanol.Models.Interfaces.projectInterfaces
{
    /// <summary>
    /// This interface defines the project for defining and using ProjectDtos and its logic.
    /// </summary>
    public interface IProjectService
    {
        /// <summary>
        /// Gets a collection of project data that hasnt been soft deleted with pagination.
        /// </summary>
        /// <returns>All of the ProyectoDTO entities</returns>
        Task<IEnumerable<ProjectGetDto>> GetAllProjectsAsync(int page, int units);

        /// <summary>
        /// Gets project record data by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>One of the project entities as a projectDTO.</returns>
        Task<ProjectGetDto> GetProjectByIdAsync(int id);

        /// <summary>
        /// Creates a project record.
        /// </summary>
        /// <param name="proyectoDto">A ProjectCreateDto.</param>
        /// <returns>A boolean value based on the creation of the project.
        /// </returns>
        Task<bool> CreateProjectAsync(ProjectCreateDto proyectoDto);

        /// <summary>
        /// Updates the project record data that hasnt been soft deleted.
        /// </summary>
        /// <param name="proyectoDto">A ProjectUpdateDto.</param>
        /// <returns>A boolean value based on the update of the project.</returns>
        Task<bool> UpdateProject(ProjectUpdateDto proyectoDto);

        /// <summary>
        /// Deletes a project record based on its id, first it soft deletes it, then it hard deletes it.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>A boolean value based on the Deletion of the project, true if it was soft or hard deleted.</returns>
        Task<bool> DeleteProjectAsync(int id);

        /// <summary>
        /// Gets a list of proyects filtered by its state.
        /// </summary>
        /// <param name="state">An int-</param>
        /// <returns>A list of project filtered by its state-</returns>
        Task<IEnumerable<ProjectGetDto>> GetProjectByStateAsync(int state);
    }
}
