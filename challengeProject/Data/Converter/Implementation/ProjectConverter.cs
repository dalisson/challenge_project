using challengeProject.Data.Converter.Contract;
using challengeProject.Data.VO;
using challengeProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace challengeProject.Data.Converter.Implementation
{
    public class ProjectConverter : IParser<ProjectVO, Project>, IParser<Project, ProjectVO>
    {
        public Project Parse(ProjectVO origin)
        {
            if (origin == null) return null;
            return new Project
            {
                Id = origin.id_projeto,
                nome = origin.nome,
                data_criacao = origin.data_criacao,
                data_termino = origin.data_termino,
                gerente = origin.gerente
            };
        }

        public List<Project> Parse(List<ProjectVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public ProjectVO Parse(Project origin)
        {
            if (origin == null) return null;
            return new ProjectVO
            {
                id_projeto = origin.Id,
                nome = origin.nome,
                data_criacao = origin.data_criacao,
                data_termino = origin.data_termino,
                gerente = origin.gerente
            };
        }

        public List<ProjectVO> Parse(List<Project> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
