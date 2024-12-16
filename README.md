# What is GraphQL?

**GraphQL** is a query language for your API and a server-side runtime for executing queries using a type system you define for your data. Open-sourced in 2015, GraphQL has since been implemented in various programming languages. It isn’t tied to any specific database or storage engine—it is backed by your existing code and data. 

---

## When Does GraphQL Become Critical?

### 1. Highly Dynamic and Complex Client Needs
**Scenario:** Multiple clients (e.g., web, mobile, IoT devices) require different subsets of data from your API.  
**Why GraphQL is Needed:**  
- Clients request only the fields they need, minimizing payload sizes.  
- A single API endpoint simplifies client-side logic.  

**Example:**  
- **E-commerce Platform:** A mobile app might need product names and prices, while the desktop site also needs descriptions, reviews, and stock status.

---

### 2. Real-Time Applications
**Scenario:** Applications requiring real-time updates (e.g., chat apps, live dashboards, or collaborative tools).  
**Why GraphQL is Needed:**  
- Subscriptions enable live updates efficiently.  

**Example:**  
- **Stock Market App:** Real-time stock price updates and user-specific portfolio data.

---

### 3. Aggregating Data from Multiple Sources
**Scenario:** Applications relying on data spread across different services (e.g., microservices or external APIs).  
**Why GraphQL is Needed:**  
- A single GraphQL query fetches data from multiple sources and unifies it in a single response.  

**Example:**  
- **Travel App:** Fetching data from APIs for flights, hotels, and car rentals.

---

### 4. Rapidly Evolving APIs
**Scenario:** APIs that change frequently (e.g., adding fields or modifying data structures).  
**Why GraphQL is Needed:**  
- Supports field deprecation without breaking existing clients.  

**Example:**  
- **Social Media App:** Adding features (e.g., reels or stories) without breaking existing queries.

---

## Developing a GraphQL API

To develop a GraphQL API, you need the following:  
- A **server-side runtime** that executes GraphQL queries against your data.  
- Tools/Frameworks by language:  
  - **JavaScript/TypeScript:** Apollo Server, Express-GraphQL, GraphQL Yoga  
  - **Python:** Graphene, Ariadne  
  - **Java:** GraphQL Java  
  - **C#/.NET:** HotChocolate, GraphQL.NET  
  - **Ruby:** GraphQL Ruby  
  - **Go:** gqlgen, GraphQL-Go  

---

## Traditional REST API Challenges

### 1. Over-fetching  
- A mobile app may receive more data than it needs (e.g., description and reviews) when calling a general `/products` endpoint.

### 2. Under-fetching  
- The desktop client may need to make multiple requests to get additional data like reviews or stock status:  
  - `/products`  
  - `/reviews`  
  - `/stock-status`  

**Comparison:**  
| **Challenge**       | **Impact**                                                                 |
|----------------------|---------------------------------------------------------------------------|
| Over-fetching        | Increases latency due to excessive data transfer, especially on slow networks. |
| Under-fetching       | Causes multiple round trips to the server, adding delays.                |

---

### 1. Mobile App Query  
The mobile app only needs `name` and `price`:  
```graphql
query {
  products {
    name
    price
  }
}
```
**Response:**  
```json
{
  "data": {
    "products": [
      { "name": "Product A", "price": 29.99 },
      { "name": "Product B", "price": 49.99 }
    ]
  }
}
```

---

### 2. Desktop Site Query  
The desktop site needs `name`, `price`, `description`, `reviews`, and `inStock`:  
```graphql
query {
  products {
    name
    price
    description
    reviews {
      content
      rating
    }
    inStock
  }
}
```
**Response:**  
```json
{
  "data": {
    "products": [
      {
        "name": "Product A",
        "price": 29.99,
        "description": "A detailed description of Product A",
        "reviews": [
          { "content": "Great product!", "rating": 5 },
          { "content": "Value for money", "rating": 4 }
        ],
        "inStock": true
      },
      {
        "name": "Product B",
        "price": 49.99,
        "description": "A detailed description of Product B",
        "reviews": [],
        "inStock": false
      }
    ]
  }
}
```

---

### 3. Combine Query  
This query fetches a list of products and customers in a single request:  
```graphql
query {
  products {
    id
    name
    price
  }
  customers {
    id
    name
    email
  }
}
```

---

## GraphQL as a Virtual Database  

### 1. Data Source Abstraction  
GraphQL acts as an **abstraction layer**, sitting on top of your actual data sources (databases, REST APIs, third-party services, etc.).  
- It doesn't store data itself but provides a unified schema to interact with multiple sources.

### 2. Schema as a "Virtual Schema"  
In a database, you define tables, columns, and relationships. Similarly, in GraphQL, you define a schema that specifies the types (objects, fields, relationships) available for queries, just like designing a "virtual schema."

---

## Querying Data: Like a SELECT Statement  

In SQL, you use `SELECT` statements to retrieve specific columns and rows from tables. Similarly, in GraphQL, you write queries to request specific fields from the schema.

### Example:  

#### SQL Example:  
```sql
SELECT id, name, email FROM Users WHERE id = 1;
```

#### GraphQL Equivalent:  
```graphql
query {
  user(id: 1) {
    id
    name
    email
  }
}
```

**In Both Cases:**  
- You specify what you need (`id`, `name`, `email`).  
- You get only the requested data in the response.

