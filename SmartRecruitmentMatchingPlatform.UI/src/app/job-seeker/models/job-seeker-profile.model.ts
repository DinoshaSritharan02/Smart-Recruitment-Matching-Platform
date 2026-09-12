export interface Skill {
  id: number;
  name: string;
}

export interface Education {
  id: string;
  institution: string;
  degree: string;
  fieldOfStudy: string;
  startDate: string;
  endDate?: string;
}

export interface Experience {
  id: string;
  companyName: string;
  jobTitle: string;
  description: string;
  startDate: string;
  endDate?: string;
}

export interface JobSeekerProfile {
  id: string;

  firstName: string;
  lastName: string;

  email: string;
  phoneNumber: string;

  dateOfBirth: string;
  gender: string;

  address: string;
  city: string;
  country: string;

  professionalSummary: string;

  skills: Skill[];

  educations: Education[];

  experiences: Experience[];
}