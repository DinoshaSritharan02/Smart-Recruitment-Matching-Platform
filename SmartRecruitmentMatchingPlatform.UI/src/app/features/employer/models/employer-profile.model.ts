export interface EmployerProfile {
  id: number;
  companyName: string;
  companyDescription: string | null;
  industry: string | null;
  companyLocation: string | null;
  website: string | null;
  createdAt: string;
  updatedAt: string;
}

export interface UpdateEmployerProfileRequest {
  companyName: string;
  companyDescription: string | null;
  industry: string | null;
  companyLocation: string | null;
  website: string | null;
}