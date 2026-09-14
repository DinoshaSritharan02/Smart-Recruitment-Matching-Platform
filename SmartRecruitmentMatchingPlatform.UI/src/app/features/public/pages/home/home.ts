import { Component } from '@angular/core';
import { Navbar } from '../../../../shared/components/navbar/navbar';
import { Footer } from '../../../../shared/components/footer/footer';
import { Hero } from '../../components/hero/hero';
import { FeaturedJobs } from '../../components/featured-jobs/featured-jobs';
import { HowItWorks } from '../../components/how-it-works/how-it-works';
import { CallToAction } from '../../components/call-to-action/call-to-action';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    Navbar,
    Hero,
    Footer,
    FeaturedJobs,
    HowItWorks,
    CallToAction
  ],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home { }