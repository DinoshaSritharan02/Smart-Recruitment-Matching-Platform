import { Routes } from '@angular/router';

export const JOB_SEEKER_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./layout/job-seeker-layout/job-seeker-layout').then(
        (m) => m.JobSeekerLayout
      ),

    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },

      {
        path: 'dashboard',
        loadComponent: () =>
          import('./dashboard/dashboard').then((m) => m.Dashboard),
      },

      {
        path: 'profile',
        loadComponent: () =>
          import('./profile/profile').then((m) => m.Profile),
      },

      {
        path: 'cv-upload',
        loadComponent: () =>
          import('./cv-upload/cv-upload').then((m) => m.CvUpload),
      },

      {
        path: 'education',
        loadComponent: () =>
          import('./education/education').then((m) => m.EducationComponent),
      },

     {
  path: 'experience',
  loadComponent: () =>
    import('./experience/experience')
      .then(m => m.ExperienceComponent)
},
      {
        path: 'skills-editor',
        loadComponent: () =>
          import('./skills-editor/skills-editor').then(
            (m) => m.SkillsEditor
          ),
      },

      {
        path: 'job-search',
        loadComponent: () =>
          import('./job-search/job-search').then((m) => m.JobSearch),
      },

      {
        path: 'job-detail/:id',
        loadComponent: () =>
          import('./job-detail/job-detail').then((m) => m.JobDetail),
      },

      {
        path: 'my-applications',
        loadComponent: () =>
          import('./my-applications/my-applications').then(
            (m) => m.MyApplications
          ),
      },
      {
    path: 'skills',
    loadComponent: () =>
        import('./skills/skills')
            .then(m => m.Skills)
},


{
  path: 'notifications',
  loadComponent: () =>
    import('./notifications/notifications')
      .then(m => m.Notifications)
},
{
  path: 'settings',
  loadComponent: () =>
    import('./settings/settings')
      .then(m => m.Settings)
},
{
  path: 'edit-profile',
  loadComponent: () =>
    import('./edit-profile/edit-profile')
      .then(m => m.EditProfile)
},

      {
        path: '**',
        redirectTo: 'dashboard',
      },
    ],
  },
];