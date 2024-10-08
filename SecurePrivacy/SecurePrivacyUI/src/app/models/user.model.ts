export class User {
  id?: string; // Optional id for identifying existing users
  name: string;
  email: string;
  consentGiven: boolean = false; // Default value for consent

  constructor(
    id: string = '',
    name: string = '',
    email: string = '',
    consentGiven: boolean = false
  ) {
    this.id = id;
    this.name = name;
    this.email = email;
    this.consentGiven = consentGiven;
  }
}
