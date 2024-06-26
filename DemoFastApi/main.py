from fastapi import FastAPI
from pydantic import BaseModel
from fastapi.middleware.cors import CORSMiddleware
import datetime
from get_data import *


class NewXs(BaseModel):
   model_name: str
   islongloan: int
   loan_amnt: float
   int_rate: float
   annual_inc: float


class SelectYear(BaseModel):
   yyyy: str


app = FastAPI()

app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


@app.get("/")
def read_root():
   x = datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')
   d = "high performance, easy to learn, fast to code, ready for production." 
   return [{"DateTime": x}, {"FastAPI": d}]


@app.get("/api/all_years")
def all_years():   
   ds = get_all_years()   
   return ds

@app.post("/api/loan_amt")
def loan_amt( selectYear: SelectYear ):
   ds = get_loan_amt(selectYear.yyyy)   
   return ds

@app.post("/api/loan_count")
def loan_count( selectYear: SelectYear ):
   ds = get_loan_count(selectYear.yyyy)   
   return ds

@app.post("/api/default_amt")
def default_amt( selectYear: SelectYear ):
   ds = get_default_amt(selectYear.yyyy)   
   return ds  

@app.post("/api/default_count")
async def default_count( selectYear: SelectYear ):
   ds = get_default_count(selectYear.yyyy)   
   return ds 

@app.post("/api/month_loan")
def month_loan( selectYear: SelectYear ):
   ds = get_month_loan(selectYear.yyyy)   
   return ds

@app.post("/api/month_count")
def month_count( selectYear: SelectYear ):
   ds = get_month_count(selectYear.yyyy)   
   return ds

@app.post("/api/purpose")
def purpose( selectYear: SelectYear ):
   ds = get_purpose(selectYear.yyyy)   
   return ds

@app.post("/api/occupation")
def occupation( selectYear: SelectYear ):
   ds = get_occupation(selectYear.yyyy)   
   return ds

@app.post("/api/ml_predict")
def occupation( newXs: NewXs ):     
   y_pred = predict_with_ml(dict(newXs))   
   return y_pred
