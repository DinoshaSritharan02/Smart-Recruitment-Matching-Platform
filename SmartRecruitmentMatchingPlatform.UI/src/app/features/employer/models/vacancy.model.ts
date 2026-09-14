export interface VacancyResponse {
  id: number;
  employerId: number;
  title: string;
  description: string | null;
  location: string | null;
  requiredExperienceYears: number;
  educationRequirement: string | null;
  status: string;
  createdAt: string;
  updatedAt: string;
  skillIds: number[];
}

export interface VacancyListItem {
  id: number;
  title: string;
  location: string | null;
  requiredExperienceYears: number;
  educationRequirement: string | null;
  status: string;
  createdAt: string;
}

export interface CreateVacancyRequest {
  title: string;
  description: string | null;
  location: string | null;
  requiredExperienceYears: number;
  educationRequirement: string | null;
  skillIds: number[];
}

export interface UpdateVacancyRequest {
  title: string;
  description: string | null;
  location: string | null;
  requiredExperienceYears: number;
  educationRequirement: string | null;
  skillIds: number[];
  isClosed: boolean;
}

export interface VacancySearchRequest {
  keyword?: string;
  location?: string;
  minExperienceYears?: number;
  maxExperienceYears?: number;
  skillId?: number;
}