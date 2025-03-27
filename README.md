# Instructions

Build with `docker build -t compatibility-testing:latest .`

Run with `docker run -it --rm -p 5660:8080 --name compatibility-testing -e OTEL_EXPORTER_OTLP_ENDPOINT=<YOUR ENDPOINT> -e OTEL_EXPORTER_OTLP_HEADERS="<YOUR HEADER>" compatibility-testing:latest`

Replace the endpoint and API key with expected values for your backend.

Once running request the test endpoints

- `http://localhost:5660` - Records a request span with child span
- `http://localhost:5660\exception` - Triggers an exception
- `http://localhost:5660\handledchildexception` - Triggers an exception which is handled in a child span