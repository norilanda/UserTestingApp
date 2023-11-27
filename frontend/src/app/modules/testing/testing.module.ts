import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestsPageComponent } from './components/tests-page/tests-page.component';
import { TestingRoutingModule } from './testing-routing.module';

@NgModule({
  declarations: [TestsPageComponent],
  imports: [CommonModule, TestingRoutingModule],
})
export class TestingModule {}
