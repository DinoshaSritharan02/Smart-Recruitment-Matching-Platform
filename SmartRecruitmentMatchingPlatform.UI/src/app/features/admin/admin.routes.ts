import { Routes } from '@angular/router';
import { AdminLayout } from './layouts/admin-layout/admin-layout';

export const ADMIN_ROUTES: Routes = [
  {
    path: '',
    component: AdminLayout,
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./pages/dashboard/dashboard').then(m => m.Dashboard)
      },
      {
        path: 'users',
        loadComponent: () =>
          import('./pages/users/users').then(m => m.Users)
      },
      {
        path: 'users/:id',
        loadComponent: () =>
          import('./pages/user-details/user-details').then(m => m.UserDetailsComponent)
      },
{
  path: 'employers',
  loadComponent: () =>
    import('./pages/employers/employers').then(m => m.Employers)
},
{
  path: 'job-seekers',
  loadComponent: () =>
    import('./pages/job-seekers/job-seekers').then(m => m.JobSeekers)
},


{
  path: 'job-seekers/:id',
  loadComponent: () =>
    import('./pages/job-seeker-details/job-seeker-details').then(m => m.JobSeekerDetails)
},
{
  path: 'jobs',
  loadComponent: () =>
    import('./pages/jobs/jobs').then(m => m.Jobs)
},

{
  path: 'job-seekers',
  loadComponent: () =>
    import('./pages/job-seekers/job-seekers').then(m => m.JobSeekers)
},

{
  path: 'reports',
  loadComponent: () =>
    import('./pages/reports/reports').then(m => m.Reports)
},

{
  path: 'settings',
  loadComponent: () =>
    import('./pages/settings/settings').then(m => m.Settings)
},


    ]
  }

];