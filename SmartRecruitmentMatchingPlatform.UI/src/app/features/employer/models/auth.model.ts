export interface LoginRequest {
  email: string;
  password: string;
}

export interface RegisterEmployerRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface RegisterJobSeekerRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export interface AuthResponse {
  token: string;
  expiresAt: string;
  role: string;
  email: string;
}