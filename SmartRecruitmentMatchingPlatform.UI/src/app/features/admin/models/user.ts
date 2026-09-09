export interface User {
  id: number;
  fullName: string;
  email: string;
  role: 'Admin' | 'Employer' | 'Job Seeker';
  status: 'Active' | 'Inactive';
  createdDate: string;
}