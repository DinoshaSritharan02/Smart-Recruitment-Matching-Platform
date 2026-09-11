import { Routes } from '@angular/router';

import { PublicLayout } from './layouts/public-layout/public-layout';

import { EmployerLayout } from './features/employer/layout/employer-layout/employer-layout';

export const routes: Routes = [
  {
    path: 'employer',
    component: EmployerLayout,
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },

      {
        path: 'dashboard',
        loadComponent: () =>
          import('./features/employer/dashboard/employer-dashboard/employer-dashboard')
            .then(m => m.EmployerDashboard)
      },

      {
        path: 'company-profile',
        loadComponent: () =>
          import('./features/employer/company-profile/company-profile/company-profile')
            .then(m => m.CompanyProfile)
      },

      {
        path: 'create-vacancy',
        loadComponent: () =>
          import('./features/employer/vacancy-management/create-vacancy/create-vacancy')
            .then(m => m.CreateVacancy)
     },
     {
  path: 'vacancies',
  loadComponent: () =>
    import('./features/employer/vacancy-management/vacancy-list/vacancy-list')
      .then(m => m.VacancyList)
     },
     {
  path: 'view-vacancy/:id',
  loadComponent: () =>
    import('./features/employer/vacancy-management/view-vacancy/view-vacancy')
      .then(m => m.ViewVacancy)
},
{
  path: 'edit-vacancy/:id',
  loadComponent: () =>
    import('./features/employer/vacancy-management/edit-vacancy/edit-vacancy')
      .then(m => m.EditVacancy)
},
 {
  path: 'required-skills',
  loadComponent: () =>
    import('./features/employer/required-skills/required-skills/required-skills')
      .then(m => m.RequiredSkills)
},
{
  path: 'applicants',
  loadComponent: () =>
    import('./features/employer/applicants/applicant-list/applicant-list')
      .then(m => m.ApplicantList)
},
{
  path: 'application-status',
  loadComponent: () =>
    import('./features/employer/applications/application-status-update/application-status-update')
      .then(m => m.ApplicationStatusUpdate)
},
{
  path: 'contact-request',
  loadComponent: () =>
    import('./features/employer/contact-request/send-contact-request/send-contact-request')
      .then(m => m.SendContactRequest)
},
{
  path: 'interviews',
  loadComponent: () =>
    import('./features/employer/interviews/interview-list/interview-list')
      .then(m => m.InterviewList)
},

{
  path: 'schedule-interview',
  loadComponent: () =>
    import('./features/employer/interviews/schedule-interview/schedule-interview')
      .then(m => m.ScheduleInterview)
},
{
  path: 'notifications',
  loadComponent: () =>
    import('./features/employer/notifications/employer-notifications/employer-notifications')
      .then(m => m.EmployerNotifications)
},
{
  path: 'settings',
  loadComponent: () =>
    import('./features/employer/settings/employer-settings/employer-settings')
      .then(m => m.EmployerSettings)
},



    ]
  },
  
  {
    path: '',
    component: PublicLayout,
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./features/public/pages/home/home')
            .then(m => m.Home)
      },
      {
        path: 'jobs',
        loadComponent: () =>
          import('./features/public/pages/jobs/jobs')
            .then(m => m.Jobs)
      },
      {
        path: 'about',
        loadComponent: () =>
          import('./features/public/pages/about/about')
            .then(m => m.About)
      },
      {
        path: 'contact',
        loadComponent: () =>
          import('./features/public/pages/contact/contact')
            .then(m => m.Contact)
      },
      {
        path: 'job-details/:id',
        loadComponent: () =>
          import('./features/public/pages/job-details/job-details')
            .then(m => m.JobDetails)
      }
      
    ]
  },
  {
  path: 'admin',
  loadChildren: () =>
    import('./features/admin/admin.routes').then((m) => m.ADMIN_ROUTES)
},

  {
    path: '**',
    redirectTo: ''
  }
];