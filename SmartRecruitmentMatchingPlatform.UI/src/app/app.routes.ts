import { Routes } from '@angular/router';

import { PublicLayout } from './layouts/public-layout/public-layout';

export const routes: Routes = [
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
    path: '**',
    redirectTo: ''
  }
];