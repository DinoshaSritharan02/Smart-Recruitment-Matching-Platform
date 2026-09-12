import { Education } from './education';
import { Experience } from './experience.model';
import { Skill } from './skill.model';

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