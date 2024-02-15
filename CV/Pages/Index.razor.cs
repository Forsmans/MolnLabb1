using CV.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CV.Pages
{
    partial class Index
    {
        [Inject]
        IHttpClientFactory httpClientFactory { get; set; }
        private HttpClient apiClient => httpClientFactory.CreateClient("CV.API");
        private List<Skill> skills { get; set; }
        private List<Education> educations { get; set; }
        private List<Job> jobs { get; set; }
        private List<Project> projects { get; set; }
        public About newAbout = new About();
        public Skill newSkill = new Skill();
        public Project newProject = new Project();
        public Education newEdc = new Education();
        public Job newJob = new Job();


        protected override async Task OnInitializedAsync()
        {
            skills = await apiClient.GetFromJsonAsync<List<Skill>>("skills");
            educations = await apiClient.GetFromJsonAsync<List<Education>>("educations");
            jobs = await apiClient.GetFromJsonAsync<List<Job>>("jobs");
            projects = await apiClient.GetFromJsonAsync<List<Project>>("projects");

        }

        private void ScrollToAbout()
        {
            Navigation.NavigateTo("#about", true);
        }

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

    }
}
