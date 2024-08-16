import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HomeComponent],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve tv shows from the server', () => {
    const mockTvShows = [
      { id: 1, name: "Example 1", favorite: true },
      { id: 2, name: "Example 2", favorite: false }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/api/TvShows');
    expect(req.request.method).toEqual('GET');
    req.flush(mockTvShows);

    expect(component.tvshows).toEqual(mockTvShows);
  });

});
