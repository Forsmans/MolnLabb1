using CV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Identity.Client;
using System.Net.Http.Json;
using CV.Models.Weather;

namespace CV.Pages
{
    partial class Index
    {
        [Inject]
        IHttpClientFactory httpClientFactory { get; set; }
        public HttpClient apiClient => httpClientFactory.CreateClient("CV.API");
        public List<Skill> skills { get; set; }
        public List<Education> educations { get; set; }
        public List<Job> jobs { get; set; }
        public List<Project> projects { get; set; }
        public List<About> abouts { get; set; }
        public Weather weather { get; set; }

        //Create
        public About newAbout = new About();
        public Skill newSkill = new Skill();
        public Project newProject = new Project();
        public Education newEdc = new Education();
        public Job newJob = new Job();

        //EDIT
        public About about = new About();
        public Skill editSkill = new Skill();
        public Project editProject = new Project();
        public Education editEdc = new Education();
        public Job editJob = new Job();


        protected override async Task OnInitializedAsync()
        {
            abouts = await apiClient.GetFromJsonAsync<List<About>>("abouts");
            about = abouts.FirstOrDefault();
            skills = await apiClient.GetFromJsonAsync<List<Skill>>("skills");
            educations = await apiClient.GetFromJsonAsync<List<Education>>("educations");
            jobs = await apiClient.GetFromJsonAsync<List<Job>>("jobs");
            projects = await apiClient.GetFromJsonAsync<List<Project>>("projects");
            weather = await apiClient.GetFromJsonAsync<Weather>("weather");

        }

        //Navigation***********************************************************************
        private void Continue()
        {
            Navigation.NavigateTo("#separator", true);
        }

        //WEATHER***********************************************************************

        private string Weather()
        {
            if (weather.Current.Rain > 0)
                return $"Its raining and {weather.Current.Temperature_2m} \u00b0C outside.";

            if(weather.Current.Temperature_2m < 10)
                return $"Its cloudy and {weather.Current.Temperature_2m} \u00b0C  outside.";

            return $"Its a beautiful day and {weather.Current.Temperature_2m} \u00b0C  outside.";
        }

        //CREATE***********************************************************************

        private async Task CreateAboutAsync()
        {
            try
            {
                await apiClient.PostAsJsonAsync<About>("about", newAbout);
                newAbout.Name = "";
                newAbout.LastName = "";
                newAbout.Age = 0;
                newAbout.Email = "";
                newAbout.Phone = "";
                newAbout.ImagePath = "";
                StateHasChanged();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating About: {ex.Message}");
            }
        }
        private async Task CreateSkillAsync()
        {
            try
            {
                await apiClient.PostAsJsonAsync<Skill>("skill", newSkill);
                newSkill.Name = "";
                newSkill.Progress = 0;
                StateHasChanged();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating About: {ex.Message}");
            }
        }

        private async Task CreateProjectAsync()
        {
            try
            {
                
                await apiClient.PostAsJsonAsync<Project>("project", newProject);
                newProject.Name = "";
                newProject.Year = 0;
                newProject.Description = "";
                newProject.ImagePath = "";
                StateHasChanged();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating About: {ex.Message}");
            }
        }

        private async Task CreateEducationAsync()
        {
            try
            {
                await apiClient.PostAsJsonAsync<Education>("education", newEdc);
                newEdc.SchoolName = "";
                newEdc.StartYear = 0;
                newEdc.EndYear = 0;
                newEdc.Title = "";
                newEdc.Description = "";
                newEdc.ImagePath = "";
                StateHasChanged();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating About: {ex.Message}");
            }
        }

        private async Task CreateJobAsync()
        {
            try
            {
                await apiClient.PostAsJsonAsync<Job>("job", newJob);
                newJob.CompanyName = "";
                newJob.StartYear = 0;
                newJob.EndYear = 0;
                newJob.Title = "";
                newJob.Description = "";
                newJob.ImagePath = "";
                StateHasChanged();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating About: {ex.Message}");
            }
        }


        //EDIT*****************************************************************************
        private async Task UpdateAboutAsync()
        {
            HttpResponseMessage response = await apiClient.PutAsJsonAsync($"about/{about.Id}", about);
        }

        private async Task UpdateSkillAsync()
        {
            HttpResponseMessage response = await apiClient.PutAsJsonAsync($"skill/{editSkill.Id}", editSkill);
        }

        private async Task SelectEditSkill(Skill skill)
        {
            editSkill = skill;
        }

        private async Task UpdateProjectAsync()
        {
            HttpResponseMessage response = await apiClient.PutAsJsonAsync($"project/{editProject.Id}", editProject);
        }

        private async Task SelectEditProject(Project project)
        {
            editProject = project;
        }
        private async Task UpdateEdcAsync()
        {
            HttpResponseMessage response = await apiClient.PutAsJsonAsync($"education/{editEdc.Id}", editEdc);
        }

        private async Task SelectEditEdc(Education education)
        {
            editEdc = education;
        }

        private async Task UpdateJobAsync()
        {
            HttpResponseMessage response = await apiClient.PutAsJsonAsync($"job/{editJob.Id}", editJob);
        }

        private async Task SelectEditJob(Job job)
        {
            editJob = job;
        }


        //DELETE***************************************************************************
        private async Task DeleteJobAsync()
        {
            HttpResponseMessage response = await apiClient.DeleteAsync($"job/{editJob.Id}");
        }
        private async Task DeleteEdcAsync()
        {
            HttpResponseMessage response = await apiClient.DeleteAsync($"education/{editEdc.Id}");
            StateHasChanged();
        }

        private async Task DeleteProjectAsync()
        {
            HttpResponseMessage response = await apiClient.DeleteAsync($"project/{editProject.Id}");
        }

        private async Task DeleteSkillAsync()
        {
            HttpResponseMessage response = await apiClient.DeleteAsync($"skill/{editSkill.Id}");
        }

    }
}
